namespace TwitchNightFall.Core.Application.ViewModels.Twitch;

public class MonitorTwitch
{
    public MonitorTwitch()
    {
        Forgiveness = new List<Domain.Entities.Forgiveness>();
    }

    public Guid? Id { get; set; }
    public Guid? TwitchId { get; set; }
    public string? Username { get; set; }
    public int TotalPrize { get; set; }
    public IEnumerable<Domain.Entities.Forgiveness> Forgiveness { get; set; }
}