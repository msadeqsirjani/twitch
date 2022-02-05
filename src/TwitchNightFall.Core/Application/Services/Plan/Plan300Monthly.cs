using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan300Monthly : IPlan
{
    public Plan300Monthly()
    {
        Id = new Guid("69B933C5-58D1-41D3-8ABC-18DC0C5A40F4");
        Title = "Subscription of 300 people per month";
        Price = 9.99;
        Count = 300;
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