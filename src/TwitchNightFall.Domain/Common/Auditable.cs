namespace TwitchNightFall.Domain.Common;

public abstract class Auditable
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}