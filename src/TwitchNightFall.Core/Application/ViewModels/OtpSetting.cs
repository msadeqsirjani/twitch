namespace TwitchNightFall.Core.Application.ViewModels;

public class OtpSetting
{
    public int Length { get; set; } = 8;

    public IList<char> PermittedLetters { get; set; } = new List<char>
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };
}