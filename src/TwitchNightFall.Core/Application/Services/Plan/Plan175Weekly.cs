using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan175Weekly : IPlan
{
    public Plan175Weekly()
    {
        Id = new Guid("8E5E29EB-2017-4D75-9CF6-7C8B8BF5B9B5");
        Title = "Purchase a subscription of 175 people per week";
        Price = 6.49;
        Count = 175;
        SubscriptionType = SubscriptionType.PurchaseFollower;
        SubscriptionTime = SubscriptionTime.Weekly;
        DelayBetweenEveryPurchase = 7;
    }

    public Guid Id { get; }
    public string? Title { get; }
    public double Price { get; }
    public int Count { get; }
    public SubscriptionType SubscriptionType { get; }
    public SubscriptionTime SubscriptionTime { get; }
    public int DelayBetweenEveryPurchase { get; }
}