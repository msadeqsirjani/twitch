using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan150Monthly : IPlan
{
    public Plan150Monthly()
    {
        Id = new Guid("8E5E29EB-2017-4D75-9CF6-7C8B8BF5B9B5");
        Title = "Subscription of 150 people per month";
        Price = 4.99;
        Count = 150;
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