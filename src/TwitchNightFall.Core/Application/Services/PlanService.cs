using Gridify;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services.Plan;

namespace TwitchNightFall.Core.Application.Services;

public interface IPlanService
{
    Task<Result> ShowPlansAsync(GridifyQuery request, Guid twitchId, CancellationToken cancellationToken = new());
}

public class PlanService : IPlanService
{
    private readonly List<IPlan> _plans;
    private readonly ISubscriptionService _subscriptionService;

    public PlanService(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
        _plans = FillPlans();
    }

    public async Task<Result> ShowPlansAsync(GridifyQuery request, Guid twitchId, CancellationToken cancellationToken = new())
    {
        var subscription =
            await _subscriptionService.FirstOrDefaultAsync(
                x => x.TwitchId == twitchId && x.ExpiredAt >= DateTime.UtcNow, cancellationToken);

        if (subscription == null) return Result.WithSuccess(_plans.AsQueryable().Gridify(request));
        
        var plan = _plans.Single(x => x.Id == subscription.PlanId);
        var message = $"{plan.Title} is active till {subscription.ExpiredAt:D}";

        return Result.WithMessage(message);
    }

    private static List<IPlan> FillPlans()
    {
        return new List<IPlan>
        {
            new Plan750Monthly(),
            new Plan600Monthly(),
            new Plan450Monthly(),
            new Plan300Monthly(),
            new Plan150Monthly(),
            new Plan175Weekly(),
            new Plan140Weekly(),
            new Plan70Weekly(),
            new Plan10Round(),
            new Plan20Round(),
            new Plan50Round()
        };
    }
}
