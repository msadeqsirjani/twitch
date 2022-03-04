using Gridify;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IPlanService : IServiceAsync<Plan>
{
    Task<Result> ShowPlansAsync(GridifyQuery request, Guid twitchId, CancellationToken cancellationToken = new());
}

public class PlanService : ServiceAsync<Plan>, IPlanService
{
    private readonly ISubscriptionService _subscriptionService;

    public PlanService(IRepositoryAsync<Plan> repository, ISubscriptionService subscriptionService) : base(repository)
    {
        _subscriptionService = subscriptionService;
    }

    public async Task<Result> ShowPlansAsync(GridifyQuery request, Guid twitchId, CancellationToken cancellationToken = new())
    {
        var subscription =
            await _subscriptionService.FirstOrDefaultAsync(
                x => x.TwitchId == twitchId && x.ExpiredAt >= DateTime.UtcNow, cancellationToken);

        var plans = Repository.Queryable(false);

        if (subscription == null) return Result.WithSuccess(plans.AsQueryable().Gridify(request));
        
        var plan = await plans.SingleOrDefaultAsync(x => x.Id == subscription.PlanId, cancellationToken);
        var message = $"{plan!.Title} is active till {subscription.ExpiredAt:D}";

        return Result.WithMessage(message);
    }
}
