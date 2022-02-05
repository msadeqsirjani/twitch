using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan450Monthly : IPlan
{
    public Plan450Monthly()
    {
        Id = new Guid("06E71005-69D6-4AD4-B218-7BD47DBEED04");
        Title = "Subscription of 450 people per month";
        Price = 14.49;
        Count = 450;
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