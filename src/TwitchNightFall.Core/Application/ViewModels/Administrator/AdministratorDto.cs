namespace TwitchNightFall.Core.Application.ViewModels.Administrator;

public class AdministratorDto
{
    public Guid Id { get; set; }
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
    /// <summary>
    /// ادمین ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}