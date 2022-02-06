using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ITransactionService : IServiceAsync<Transaction>
{
    Task<Result> PayAsync(Transaction transaction, CancellationToken cancellationToken = new());
}

public class TransactionService : ServiceAsync<Transaction>, ITransactionService
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;

    public TransactionService(IRepositoryAsync<Transaction> repository, ISubscriptionService subscriptionService, IUnitOfWorkAsync unitOfWorkAsync) : base(repository)
    {
        _subscriptionService = subscriptionService;
        _unitOfWorkAsync = unitOfWorkAsync;
    }

    public async Task<Result> PayAsync(Transaction transaction, CancellationToken cancellationToken = new())
    {
        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            PlanId = transaction.PlanId,
            TwitchId = transaction.TwitchId
        };

        await _subscriptionService.SubscribeAsync(subscription, cancellationToken);

        transaction.Id = Guid.NewGuid();

        await Repository.AddAsync(transaction, cancellationToken);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

        return Result.WithSuccess(Statement.Success);
    }
}