using TwitchNightFall.Core.Application.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan50Round : IPlan
{
    public Plan50Round()
    {
        Id = new Guid("95DF2344-8FB7-4F20-BB51-F1BF1F5618C0");
        Title = "50 rounds of luck one to five followers";
        Price = 3.49;
        Count = 50;
        SubscriptionType = SubscriptionType.LuckRound;
        SubscriptionTime = SubscriptionTime.Daily;
        DelayBetweenEveryPurchase = 10;
    }

    public Guid Id { get; }
    public string? Title { get; }
    public double Price { get; }
    public int Count { get; }
    public SubscriptionType SubscriptionType { get; }
    public SubscriptionTime SubscriptionTime { get; }
    public int DelayBetweenEveryPurchase { get; }
}