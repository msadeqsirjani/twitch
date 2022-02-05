using Gridify;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services.Subscription;

namespace TwitchNightFall.Core.Application.Services;

public interface ISubscriptionService
{
    Result GetSubscriptions(GridifyQuery request);
}

public class SubscriptionServiceService : ISubscriptionService
{
    private readonly List<ISubscription> _subscriptions;

    public SubscriptionServiceService()
    {
        _subscriptions = FillSubscriptions();
    }

    public Result GetSubscriptions(GridifyQuery request)
    {
        return Result.WithSuccess(_subscriptions.AsQueryable().Gridify(request));
    }

    private static List<ISubscription> FillSubscriptions()
    {
        return new List<ISubscription>
        {
            new Plan750MonthlySubscription(),
            new Plan600MonthlySubscription(),
            new Plan450MonthlySubscription(),
            new Plan300MonthlySubscription(),
            new Plan150MonthlySubscription(),
            new Plan175WeeklySubscription(),
            new Plan140WeeklySubscription(),
            new Plan70WeeklySubscription(),
            new Plan10RoundSubscription(),
            new Plan20RoundSubscription(),
            new Plan50RoundSubscription()
        };
    }
}
