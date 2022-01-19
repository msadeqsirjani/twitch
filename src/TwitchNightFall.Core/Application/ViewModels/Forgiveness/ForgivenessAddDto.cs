using TwitchNightFall.Core.Application.ViewModels.Common;

namespace TwitchNightFall.Core.Application.ViewModels.Forgiveness;

public class ForgivenessAddDto : AuditableAddDto
{
    public ForgivenessAddDto()
    {
        
    }

    public ForgivenessAddDto(int prize)
    {
        Prize = prize;
    }

    public int Prize { get; set; }
}