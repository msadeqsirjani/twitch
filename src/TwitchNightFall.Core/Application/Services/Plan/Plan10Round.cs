using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan10Round : IPlan
{
    public Plan10Round()
    {
        Id = new Guid("42A62722-2C58-4F59-A81F-487141A288BB");
        Title = "10 rounds of luck one to five followers";
        Price = 0.99;
        Count = 10;
        SubscriptionType = SubscriptionType.LuckRound;
        SubscriptionTime = SubscriptionTime.Daily;
        DelayBetweenEveryPurchase = 5;
    }

    public Guid Id { get; }
    public string? Title { get; }
    public double Price { get; }
    public int Count { get; }
    public SubscriptionType SubscriptionType { get; }
    public SubscriptionTime SubscriptionTime { get; }
    public int DelayBetweenEveryPurchase { get; }
}