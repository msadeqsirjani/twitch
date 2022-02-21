namespace TwitchNightFall.Core.Application.ViewModels.Administrator;

public class AdministratorDto
{
    public Guid Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public Guid? CreatedBy { get; set; }
}