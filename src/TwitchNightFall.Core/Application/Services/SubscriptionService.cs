using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Common.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
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

    Task<Result> ShowFollowerBoundary(Guid twitchId, CancellationToken cancellationToken = new());
}

public class SubscriptionService : ServiceAsync<Subscription>, ISubscriptionService
{
    private readonly IPlanRepository _planRepository;
    private readonly IForgivenessRepository _forgivenessRepository;
    private readonly TwitchSetting _options;

    public SubscriptionService(IRepositoryAsync<Subscription> repository, IPlanRepository planRepository, IForgivenessRepository forgivenessRepository, IOptions<TwitchSetting> options) : base(repository)
    {
        _planRepository = planRepository;
        _forgivenessRepository = forgivenessRepository;
        _options = options.Value;
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
            var forgiveness = new Forgiveness(subscription.TwitchId, plan.Count, ForgivenessType.Subscription, plan.Id);

            await _forgivenessRepository.AddAsync(forgiveness, cancellationToken);
        }

        subscription.ExpiredAt = DateTime.UtcNow.AddDays(plan.DelayBetweenEveryPurchase);

        await Repository.AddAsync(subscription, cancellationToken);

        return Result.WithSuccess(Statement.Success);
    }

    public async Task<Result> ShowFollowerBoundary(Guid twitchId, CancellationToken cancellationToken = new())
    {
        var now = DateTime.UtcNow;

        var subscription = await Repository.Queryable(false)
            .Include(x => x.Plan)
            .ThenInclude(x => x.Forgiveness)
            .FirstOrDefaultAsync(x => x.ExpiredAt >= now && x.TwitchId == twitchId, cancellationToken);

        int boundary;

        if (subscription == null)
        {
            boundary = _options.FollowerBoundary - await _forgivenessRepository.CountAsync(x =>
               x.TwitchId == twitchId && EF.Functions.DateDiffDay(x.CreatedAt, now) == 0 &&
               x.ForgivenessType == ForgivenessType.Free, cancellationToken);
        }
        else
        {
            if (subscription.Plan?.PlanType == PlanType.LuckRound)
                boundary = subscription.Plan?.Count - subscription.Plan?.Forgiveness.Count ?? 0;
            else
                boundary = 0;
        }

        return Result.WithSuccess(boundary);
    }
}