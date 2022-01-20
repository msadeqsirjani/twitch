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

    /// <summary>
    /// نام
    /// </summary>
    public string? Firstname { get; set; }
    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string? Lastname { get; set; }
    /// <summary>
    /// نشانی نمایش تصویر پروفایل
    /// </summary>
    public string? ProfileImageUrl { get; set; }
    /// <summary>
    /// نام کابری
    /// </summary>
    public string? Username { get; set; }
    /// <summary>
    /// کلمه عبور
    /// </summary>
    public string? Password { get; set; }
}