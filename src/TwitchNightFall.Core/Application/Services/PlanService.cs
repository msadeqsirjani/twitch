using Gridify;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services.Plan;

namespace TwitchNightFall.Core.Application.Services;

public interface IPlanService
{
    Result ShowPlans(GridifyQuery request);
}

public class PlanService : IPlanService
{
    private readonly List<IPlan> _subscriptions;

    public PlanService()
    {
        _subscriptions = FillSubscriptions();
    }

    public Result ShowPlans(GridifyQuery request)
    {
        return Result.WithSuccess(_subscriptions.AsQueryable().Gridify(request));
    }

    private static List<IPlan> FillSubscriptions()
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
