using Gridify;
using Microsoft.EntityFrameworkCore;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels.Transaction;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ITransactionService : IServiceAsync<Transaction>
{
    Task<Result> PayAsync(Transaction transaction, CancellationToken cancellationToken = new());
    Result ShowTransaction(GridifyQuery request);
}

public class TransactionService : ServiceAsync<Transaction>, ITransactionService
{
    private readonly IPlanService _planService;
    private readonly ISubscriptionService _subscriptionService;
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;
    private readonly ITransactionVerificationService _transactionVerificationService;

    public TransactionService(IRepositoryAsync<Transaction> repository, ISubscriptionService subscriptionService,
        IUnitOfWorkAsync unitOfWorkAsync, IPlanService planService,
        ITransactionVerificationService transactionVerificationService) : base(repository)
    {
        _subscriptionService = subscriptionService;
        _unitOfWorkAsync = unitOfWorkAsync;
        _planService = planService;
        _transactionVerificationService = transactionVerificationService;
    }

    public async Task<Result> PayAsync(Transaction transaction, CancellationToken cancellationToken = new())
    {
        var existSubscription = await _subscriptionService.GetSubscriptionAsync(x => x.ExpiredAt >= DateTime.UtcNow, cancellationToken);

        if (existSubscription != null)
            throw new MessageException("پایان اعتبار مدت اشتراکی شما به اتمام نرسیده است");

        var plan = await _planService.FirstOrDefaultAsync(transaction.PlanId, cancellationToken);

        if (plan == null)
            throw new MessageException("پلنی با این شناسه یافت نشد");

        if (!string.IsNullOrEmpty(transaction.PaymentId) &&
            (await _transactionVerificationService.VerifyAsync(transaction.PaymentId, cancellationToken)).Value != true)
            throw new MessageException("شناسه پرداخت معنبر نمی باشد");

        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            PlanId = transaction.PlanId,
            TwitchId = transaction.TwitchId
        };

        await _subscriptionService.SubscribeAsync(subscription, cancellationToken);

        transaction.Id = Guid.NewGuid();
        transaction.Price = plan.Price;

        await Repository.AddAsync(transaction, cancellationToken);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

        return Result.WithSuccess(Statement.Success);
    }

    public Result ShowTransaction(GridifyQuery request)
    {
        var transactions = Repository.Queryable(false)
            .Include(x => x.Plan)
            .Include(x => x.Twitch)
            .Select(x => new TransactionDto()
            {
                Id = x.Id,
                PlanId = x.PlanId,
                PlanTitle = x.Plan!.Title,
                PlanPrice = x.Price,
                PlanTime = x.Plan!.PlanTime,
                PlanType = x.Plan!.PlanType,
                Username = x.Twitch!.Username,
                PaymentId = x.PaymentId,
                TwitchId = x.TwitchId,
                CreatedAt = x.CreatedAt
            })
            .OrderByDescending(x => x.CreatedAt)
            .Gridify(request);

        return Result.WithSuccess(transactions);
    }
}