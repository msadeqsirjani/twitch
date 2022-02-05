using TwitchNightFall.Domain.Common;
using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Domain.Entities;

public class Subscription : Auditable
{
    public Guid TwitchId { get; set; }
    public Guid PlanId { get; set; }
    public PlanType PlanType { get; set; }
    public PlanTime PlanTime { get; set; }
    public DateTime ExpiredAt { get; set; }

    public Twitch? Twitch { get; set; }
}