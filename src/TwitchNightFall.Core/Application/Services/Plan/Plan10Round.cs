using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Application.Services.Plan;

public class Plan10Round : IPlan
{
    public Plan10Round()
    {
        Id = new Guid("42A62722-2C58-4F59-A81F-487141A288BB");
        Title = "10 rounds of luck one to five followers";
        Price = 0.99;
        Count = 10;
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