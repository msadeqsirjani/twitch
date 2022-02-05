using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan70Weekly : IPlan
{
    public Plan70Weekly()
    {
        Id = new Guid("8D96397F-A217-43A7-8F9B-91CFF10FD135");
        Title = "Subscription of 70 people per week";
        Price = 2.99;
        Count = 70;
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