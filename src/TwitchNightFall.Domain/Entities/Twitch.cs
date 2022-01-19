using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class Twitch : Auditable
{
    public Twitch()
    {
        
    }

    public Twitch(string username)
    {
        Id = Guid.NewGuid();
        Username = username;
    }

    public string Username { get; set; }

    public ICollection<Forgiveness> Forgiveness { get; set; }
}