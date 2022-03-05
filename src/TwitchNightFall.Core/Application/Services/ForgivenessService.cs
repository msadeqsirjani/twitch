using Gridify;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Common.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Core.Application.ViewModels.Forgiveness;
using TwitchNightFall.Core.Application.ViewModels.Twitch;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Enums;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IForgivenessService : IServiceAsync<Forgiveness>
{
    Task<Result> Forgiveness(Guid twitchId, int prize, CancellationToken cancellationToken = new());
    Task<Result> CompleteAsync(Guid id, Guid administrator, CancellationToken cancellationToken = new());
    Paging<MonitorTwitch> ShowDetail(GridifyQuery request);
    Paging<ForgivenessDto> ShowHistory(GridifyQuery request);
}

public class ForgivenessService : ServiceAsync<Forgiveness>, IForgivenessService
{
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;
    private readonly ITwitchService _twitchService;
    private readonly ISubscriptionService _subscriptionService;
    private readonly TwitchSetting _options;

    public ForgivenessService(IRepositoryAsync<Forgiveness> repository,
        IUnitOfWorkAsync unitOfWorkAsync,
        IOptions<TwitchSetting> options,
        ITwitchService twitchService,
        ISubscriptionService subscriptionService) : base(repository)
    {
        _unitOfWorkAsync = unitOfWorkAsync;
        _twitchService = twitchService;
        _subscriptionService = subscriptionService;
        _options = options.Value;
    }

    public async Task<Result> Forgiveness(Guid twitchId, int prize, CancellationToken cancellationToken = new())
    {
        var isFirstForgiveness = false;
        if (prize is > 5 or < 0)
            throw new MessageException("The number of gifted followers can not be less than 0 and more than 5");

        var now = DateTime.UtcNow;

        int count;

        var subscription = await _subscriptionService.GetSubscriptionAsync(
            x => x.ExpiredAt >= now, cancellationToken);

        if(subscription?.Plan?.PlanType == PlanType.PurchaseFollower)
            return Result.WithMessage("You can not spin the wheel due to the sharing scheme being active");

        if (subscription != null)
        {
            count = await Repository.CountAsync(x =>
                x.TwitchId == twitchId && x.PlanId == subscription.PlanId &&
                x.ForgivenessType == ForgivenessType.Subscription, cancellationToken);

            if (count >= subscription.Plan?.Count)
                throw new MessageException($"Each username can only use this feature {subscription.Plan!.Count} times a day");
        }
        else
        {
            count = await Repository.CountAsync(x =>
                x.TwitchId == twitchId && EF.Functions.DateDiffDay(x.CreatedAt, now) == 0 &&
                x.ForgivenessType == ForgivenessType.Free, cancellationToken);

            if (count >= _options.FollowerBoundary)
                throw new MessageException($"Each username can only use this feature {_options.FollowerBoundary} times a day");
        }

        if (!await _twitchService.ExistsAsync(x => x.Id == twitchId, cancellationToken))
            throw new MessageException("No user with such an ID was found");

        Forgiveness forgiveness;
        if (!await Repository.ExistsAsync(x => x.TwitchId == twitchId, cancellationToken))
        {
            forgiveness = new Forgiveness(twitchId, _options.FollowerGift, ForgivenessType.Gift);

            await Repository.AddAsync(forgiveness, cancellationToken);

            isFirstForgiveness = true;
        }

        forgiveness = new Forgiveness(twitchId, prize,
            subscription == null ? ForgivenessType.Free : ForgivenessType.Subscription, subscription?.PlanId);

        await Repository.AddAsync(forgiveness, cancellationToken);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

        return Result.WithSuccess(new { IsFirstForgiveness = isFirstForgiveness }, Statement.Success);
    }

    public async Task<Result> CompleteAsync(Guid id, Guid administrator, CancellationToken cancellationToken = new())
    {
        var forgiveness = await Repository.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (forgiveness == null)
            throw new MessageException("Lottery ID is not available");

        forgiveness.IsChecked = true;
        forgiveness.ModifiedBy = administrator;

        Repository.Attach(forgiveness);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

        return Result.WithSuccess(Statement.Success);
    }

    public Paging<MonitorTwitch> ShowDetail(GridifyQuery request)
    {
        var twitches = Repository.Queryable(false)
            .Include(x => x.Twitch)
            .Select(x => x.TwitchId)
            .Distinct()
            .Select(twitchId => new
            {
                TwitchId = twitchId,
                Forgiveness = Repository.Queryable(false)
                    .Where(y => y.TwitchId == twitchId && EF.Functions.DateDiffDay(y.CreatedAt, DateTime.UtcNow) == 0)
                    .OrderByDescending(y => y.IsChecked)
                    .ThenByDescending(x => x.CreatedAt)
                    .ThenByDescending(y => y.ModifiedAt)
                    .ToList()
            })
            .Select(x => new MonitorTwitch
            {
                Id = x.Forgiveness.Single().Id,
                TwitchId = x.TwitchId,
                Username = x.Forgiveness.Single().Twitch.Username,
                TotalPrize = x.Forgiveness.Sum(y => y.Prize),
                Forgiveness = x.Forgiveness
            })
            .Gridify(request);

        return twitches;

    }

    public Paging<ForgivenessDto> ShowHistory(GridifyQuery request)
    {
        var twitches = Repository.Queryable(false)
            .Select(x => new ForgivenessDto
            {
                Id = x.Id,
                Prize = x.Prize,
                TwitchId = x.TwitchId,
                Username = x.Twitch.Username,
                CreatedAt = x.CreatedAt,
                IsChecked = x.IsChecked,
                ModifiedAt = x.ModifiedAt
            })
            .OrderByDescending(x => x.IsChecked)
            .ThenByDescending(x => x.CreatedAt)
            .ThenByDescending(x => x.ModifiedAt)
            .Gridify(request);

        return twitches;
    }
}