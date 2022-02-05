using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public interface IPlan
{
    Guid Id { get; }
    string? Title { get; }
    double Price { get; }
    int Count { get; }
    PlanType PlanType { get; }
    PlanTime PlanTime { get; }
    int DelayBetweenEveryPurchase { get; }
}