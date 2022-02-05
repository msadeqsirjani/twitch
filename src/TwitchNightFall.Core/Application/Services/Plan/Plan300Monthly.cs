using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan300Monthly : IPlan
{
    public Plan300Monthly()
    {
        Id = new Guid("69B933C5-58D1-41D3-8ABC-18DC0C5A40F4");
        Title = "Purchase a subscription of 300 people per month";
        Price = 9.99;
        Count = 300;
        SubscriptionType = SubscriptionType.PurchaseFollower;
        SubscriptionTime = SubscriptionTime.Monthly;
        DelayBetweenEveryPurchase = 30;
    }

    public Guid Id { get; }
    public string? Title { get; }
    public double Price { get; }
    public int Count { get; }
    public SubscriptionType SubscriptionType { get; }
    public SubscriptionTime SubscriptionTime { get; }
    public int DelayBetweenEveryPurchase { get; }
}