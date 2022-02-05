using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan600Monthly : IPlan
{
    public Plan600Monthly()
    {
        Id = new Guid("F75A9840-2C97-4F1C-91A0-FD6C68D49F4A");
        Title = "Subscription of 600 people per month";
        Price = 18.99;
        Count = 600;
        PlanType = PlanType.PurchaseFollower;
        PlanTime = PlanTime.Monthly;
        DelayBetweenEveryPurchase = 30;
    }

    public Guid Id { get; }
    public string? Title { get; }
    public double Price { get; }
    public int Count { get; }
    public PlanType PlanType { get; }
    public PlanTime PlanTime { get; }
    public int DelayBetweenEveryPurchase { get; }
}