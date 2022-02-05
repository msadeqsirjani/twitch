using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan750Monthly : IPlan
{
    public Plan750Monthly()
    {
        Id = new Guid("5F31BB44-BA41-4CBA-97E5-E0152BAEB259");
        Title = "Subscription of 750 people per month";
        Price = 22.99;
        Count = 750;
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