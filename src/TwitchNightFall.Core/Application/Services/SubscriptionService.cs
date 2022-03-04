using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
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

    Task<Result> ShowActivePlanAsync(Guid twitchId, CancellationToken cancellationToken = new());
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

    public async Task<Result> ShowActivePlanAsync(Guid twitchId, CancellationToken cancellationToken = new())
    {
        var subscription = await Repository.Queryable(false)
            .Include(x => x.Plan)
            .ThenInclude(x => x.Forgiveness)
            .FirstOrDefaultAsync(x => x.ExpiredAt >= DateTime.UtcNow && x.TwitchId == twitchId, cancellationToken);

        if(subscription == null)
            return Result.WithMessage("There is no active plan");

        var result = new
        {
            Plan = new
            {
                subscription?.Plan?.Id,
                subscription?.Plan?.Title,
                subscription?.Plan?.Count,
                subscription?.Plan?.DelayBetweenEveryPurchase,
                subscription?.Plan?.PlanType,
                subscription?.Plan?.PlanTime,
                subscription?.Plan?.Price,
                subscription?.Plan?.CreatedAt,
                subscription?.Plan?.ModifiedAt,
            },
            Usage = subscription?.Plan?.Count - subscription?.Plan?.Forgiveness.Sum(x => x.Prize)
        };

        return Result.WithSuccess(result);
    }
}