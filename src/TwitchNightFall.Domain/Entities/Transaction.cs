using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class Transaction : Auditable
{
    public Guid TwitchId { get; set; }
    public Guid PlanId { get; set; }
    public double Price { get; set; }

    public Twitch? Twitch { get; set; }
    public Plan? Plan { get; set; }
}