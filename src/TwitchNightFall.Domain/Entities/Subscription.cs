using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class Subscription : Auditable
{
    public Guid TwitchId { get; set; }
    public Guid PlanId { get; set; }
    public DateTime ExpiredAt { get; set; }

    public Twitch? Twitch { get; set; }
}