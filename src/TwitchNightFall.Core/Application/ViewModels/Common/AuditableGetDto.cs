namespace TwitchNightFall.Core.Application.ViewModels.Common;

public abstract class AuditableGetDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}