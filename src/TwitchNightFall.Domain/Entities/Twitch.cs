using TwitchNightFall.Common.Exceptions;
using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class Twitch : Auditable
{
    public Twitch()
    {
        Forgiveness = new List<Forgiveness>();
        Subscription = new List<Subscription>();
        Transaction = new List<Transaction>();
    }

    public Twitch(string username) : this()
    {
        if (string.IsNullOrEmpty(username))
            throw new MessageException("Username cannot be empty");

        if (username.Length > 250)
            throw new MessageException("Username can not be longer than 250 characters");

        Id = Guid.NewGuid();
        Username = username;
    }

    public string Username { get; set; }

    public ICollection<Forgiveness> Forgiveness { get; set; }
    public ICollection<Subscription> Subscription { get; set; }
    public ICollection<Transaction> Transaction { get; set; }
}