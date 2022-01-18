using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class TwitchAccount : Auditable
{
    public TwitchAccount()
    {
        
    }

    public TwitchAccount(string username)
    {
        Id = Guid.NewGuid();
        Username = username;
    }

    public string Username { get; set; }

    public ICollection<FollowerAward> FollowerAwards { get; set; }
}