using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class Forgiveness : Auditable
{
    public Forgiveness()
    {
        
    }

    public Forgiveness(Guid twitchId, int prize)
    {
        Id = Guid.NewGuid();
        TwitchId = twitchId;
        Prize = prize;
    }

    public Guid TwitchId { get; set; }
    public int Prize { get; set; }
    public bool IsChecked { get; set; }

    public Twitch? TwitchAccount { get; set; }
}