using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.ViewModels.Subscription;

public class Subscription
{
    public Subscription()
    {
        
    }

    public Subscription(Guid id, string? title, double price, int count, SubscriptionType subscriptionType, SubscriptionTime subscriptionTime, int delayBetweenEveryPurchase)
    {
        Id = id;
        Title = title;
        Price = price;
        Count = count;
        SubscriptionType = subscriptionType;
        SubscriptionTime = subscriptionTime;
        DelayBetweenEveryPurchase = delayBetweenEveryPurchase;
    }

    public Guid Id { get; set; }
    public string? Title { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public SubscriptionTime SubscriptionTime { get; set; }
    public int DelayBetweenEveryPurchase { get; set; }
}