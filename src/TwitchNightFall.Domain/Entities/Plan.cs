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

    public string? Title { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
    public PlanType PlanType { get; set; }
    public PlanTime PlanTime { get; set; }
    public int DelayBetweenEveryPurchase { get; set; }

    public ICollection<Subscription> Subscription { get; set; }
    public ICollection<Transaction> Transaction { get; set; }
}