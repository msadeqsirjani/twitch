using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan50Round : IPlan
{
    public Plan50Round()
    {
        Id = new Guid("95DF2344-8FB7-4F20-BB51-F1BF1F5618C0");
        Title = "50 rounds of luck one to five followers";
        Price = 3.49;
        Count = 50;
        PlanType = PlanType.LuckRound;
        PlanTime = PlanTime.Daily;
        DelayBetweenEveryPurchase = 10;
    }

    public Guid Id { get; }
    public string? Title { get; }
    public double Price { get; }
    public int Count { get; }
    public PlanType PlanType { get; }
    public PlanTime PlanTime { get; }
    public int DelayBetweenEveryPurchase { get; }
}