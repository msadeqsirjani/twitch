using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan20Round : IPlan
{
    public Plan20Round()
    {
        Id = new Guid("B55BCAAB-901E-4D30-8E82-E5572B84937C");
        Title = "20 rounds of luck one to five followers";
        Price = 1.89;
        Count = 20;
        PlanType = PlanType.LuckRound;
        PlanTime = PlanTime.Daily;
        DelayBetweenEveryPurchase = 5;
    }

    public Guid Id { get; }
    public string? Title { get; }
    public double Price { get; }
    public int Count { get; }
    public PlanType PlanType { get; }
    public PlanTime PlanTime { get; }
    public int DelayBetweenEveryPurchase { get; }
}