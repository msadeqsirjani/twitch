using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Domain.Entities;

public class ResetPassword : Auditable
{
    public ResetPassword()
    {
        
    }

    public ResetPassword(string? email, string singleUseCode)
    {
        Id = Guid.NewGuid();
        Email = email;
        SingleUseCode = singleUseCode;
        Expiry = DateTime.UtcNow.AddMinutes(5);
    }

    public string? Email { get; set; }
    public string SingleUseCode { get; set; }
    public DateTime Expiry { get; set; }
}