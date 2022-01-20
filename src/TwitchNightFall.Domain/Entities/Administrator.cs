using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class Administrator : Auditable
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}