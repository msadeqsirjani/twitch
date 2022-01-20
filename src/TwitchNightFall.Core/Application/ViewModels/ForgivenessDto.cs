namespace TwitchNightFall.Core.Application.ViewModels;

public class ForgivenessDto
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public Guid TwitchId { get; set; }
    public int Prize { get; set; }
    public bool IsChecked { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}