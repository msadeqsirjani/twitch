using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class Twitch : Auditable
{
    public Twitch()
    {
        
    }

    public Twitch(string username, string email, string password)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        Password = password;
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<Forgiveness> Forgiveness { get; set; }
    public ICollection<Subscription> Subscription { get; set; }
}