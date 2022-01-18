using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class FollowerAward : Auditable
{
    public FollowerAward()
    {
        
    }

    public FollowerAward(Guid twitchAccountId, int prize)
    {
        Id = Guid.NewGuid();
        TwitchAccountId = twitchAccountId;
        Prize = prize;
    }

    public Guid TwitchAccountId { get; set; }
    public int Prize { get; set; }
    public bool IsChecked { get; set; }

    public TwitchAccount? TwitchAccount { get; set; }
}