using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan140Weekly : IPlan
{
    public Plan140Weekly()
    {
        Id = new Guid("4B01F654-1410-492C-8B97-BBB9E142B372");
        Title = "Subscription of 140 people per week";
        Price = 5.49;
        Count = 140;
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