using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Common.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Enums;
using TwitchNightFall.Domain.Repository;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ISubscriptionService : IServiceAsync<Subscription>
{
    Task<Subscription?> GetSubscriptionAsync(Expression<Func<Subscription, bool>> predicate,
        CancellationToken cancellationToken = new());

    Task<Result> SubscribeAsync(Subscription subscription, CancellationToken cancellationToken = new());
}

public class SubscriptionService : ServiceAsync<Subscription>, ISubscriptionService
{
    private readonly IPlanRepository _planRepository;
    private readonly IForgivenessRepository _forgivenessRepository;

    public SubscriptionService(IRepositoryAsync<Subscription> repository, IPlanRepository planRepository, IForgivenessRepository forgivenessRepository) : base(repository)
    {
        _planRepository = planRepository;
        _forgivenessRepository = forgivenessRepository;
    }

    public async Task<Subscription?> GetSubscriptionAsync(Expression<Func<Subscription, bool>> predicate,
        CancellationToken cancellationToken = new())
    {
        return await Repository.Queryable()
            .Include(x => x.Plan)
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Result> SubscribeAsync(Subscription subscription, CancellationToken cancellationToken = new())
    {
        var plan = await _planRepository.Queryable(false)
            .FirstOrDefaultAsync(x => x.Id == subscription.PlanId, cancellationToken);

        if (plan == null)
            throw new MessageException("There is no plan with this ID");

        if (plan.PlanType == PlanType.PurchaseFollower)
        {
            var forgiveness = new Forgiveness(subscription.TwitchId, plan.Count, ForgivenessType.Subscription);

            await _forgivenessRepository.AddAsync(forgiveness, cancellationToken);
        }

        subscription.ExpiredAt = DateTime.UtcNow.AddDays(plan.DelayBetweenEveryPurchase);

        await Repository.AddAsync(subscription, cancellationToken);

        return Result.WithSuccess(Statement.Success);
    }
}