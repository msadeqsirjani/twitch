using TwitchNightFall.Domain.Common;
using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Domain.Entities;

public class Plan : Auditable
{
    public Plan()
    {
        Subscription = new List<Subscription>();
        Transaction = new List<Transaction>();
    }

    public Plan(Guid id, string? title, double price, int count, PlanType planType, PlanTime planTime, int delayBetweenEveryPurchase) : this()
    {
        Id = id;
        Title = title;
        Price = price;
        Count = count;
        PlanType = planType;
        PlanTime = planTime;
        DelayBetweenEveryPurchase = delayBetweenEveryPurchase;
    }

    public string? Title { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
    public PlanType PlanType { get; set; }
    public PlanTime PlanTime { get; set; }
    public int DelayBetweenEveryPurchase { get; set; }

    public ICollection<Subscription> Subscription { get; set; }
    public ICollection<Transaction> Transaction { get; set; }
}