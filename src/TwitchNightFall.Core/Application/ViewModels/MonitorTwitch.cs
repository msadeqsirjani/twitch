using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Application.ViewModels;

public class MonitorTwitch
{
    public Guid? Id { get; set; }
    public Guid? TwitchId { get; set; }
    public string? Username { get; set; }
    public int TotalPrize { get; set; }
    public IEnumerable<Forgiveness> Forgiveness { get; set; }
}