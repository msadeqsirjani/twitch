﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Infra.Data.Repository;
using TwitchNightFall.Domain.Entities;
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

    public SubscriptionService(IRepositoryAsync<Subscription> repository, IPlanRepository planRepository) : base(repository)
    {
        _planRepository = planRepository;
    }

    public async Task<Subscription?> GetSubscriptionAsync(Expression<Func<Subscription, bool>> predicate,
        CancellationToken cancellationToken = new())
    {
        return await Repository.Queryable()
            .Include(x => x.Plan)
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<Result> SubscribeAsync(Subscription subscription, CancellationToken cancellationToken = new())
    {
        var plan = await _planRepository.Queryable(false)
            .FirstOrDefaultAsync(x => x.Id == subscription.PlanId, cancellationToken);

        if (plan == null)
            throw new MessageException("پلنی با این شناسه موجود نمی باشد");

        subscription.ExpiredAt = DateTime.UtcNow.AddDays(plan.DelayBetweenEveryPurchase);

        await Repository.AddAsync(subscription, cancellationToken);

        return Result.WithSuccess(Statement.Success);
    }
}