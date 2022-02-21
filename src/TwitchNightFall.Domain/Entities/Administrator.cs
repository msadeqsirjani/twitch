using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class Administrator : Auditable
{
    public Administrator()
    {
        
    }

    public Administrator(string? firstname, string? lastname, string? profileImageUrl, string? username, string? password)
    {
        Firstname = firstname;
        Lastname = lastname;
        ProfileImageUrl = profileImageUrl;
        Username = username;
        Password = password;
    }

    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public Guid? CreatedBy { get; set; }
    public bool IsActive { get; set; }

    
    public Administrator? Creator { get; set; }
    public ICollection<Forgiveness> Forgiveness { get; set; }
}