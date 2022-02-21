using TwitchNightFall.Domain.Common;
using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Domain.Entities;

public class Forgiveness : Auditable
{
    public Forgiveness()
    {
        
    }

    public Forgiveness(Guid twitchId, int prize, ForgivenessType forgivenessType)
    {
        Id = Guid.NewGuid();
        TwitchId = twitchId;
        Prize = prize;
        ForgivenessType = forgivenessType;
    }

    public Guid TwitchId { get; set; }
    public int Prize { get; set; }
    public bool IsChecked { get; set; }
    public ForgivenessType ForgivenessType { get; set; }
    public Guid? ModifiedBy { get; set; }

    public Twitch Twitch { get; set; }
    public Administrator? Administrator { get; set; }
}