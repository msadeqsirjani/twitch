using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public interface IPlan
{
    Guid Id { get; }
    string? Title { get; }
    double Price { get; }
    int Count { get; }
    SubscriptionType SubscriptionType { get; }
    SubscriptionTime SubscriptionTime { get; }
    int DelayBetweenEveryPurchase { get; }
}