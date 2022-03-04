using TwitchNightFall.Domain.Common;
using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Domain.Entities;

public class Forgiveness : Auditable
{
    public Forgiveness()
    {
        
    }

    public Forgiveness(Guid twitchId, int prize, ForgivenessType forgivenessType, Guid? planId = null)
    {
        Id = Guid.NewGuid();
        TwitchId = twitchId;
        Prize = prize;
        ForgivenessType = forgivenessType;
        PlanId = planId;
    }

    public Guid TwitchId { get; set; }
    public int Prize { get; set; }
    public bool IsChecked { get; set; }
    public ForgivenessType ForgivenessType { get; set; }
    public Guid? PlanId { get; set; }
    public Guid? ModifiedBy { get; set; }

    public Twitch Twitch { get; set; }
    public Plan Plan { get; set; }
    public Administrator? Administrator { get; set; }
}