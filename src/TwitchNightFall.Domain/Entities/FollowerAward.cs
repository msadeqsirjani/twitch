using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class FollowerAward : Auditable
{
    public Guid TwitchAccountId { get; set; }
    public int Prize { get; set; }

    public TwitchAccount? TwitchAccount { get; set; }
}