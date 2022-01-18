using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchNightFall.Core.Application.ViewModels.Common;

namespace TwitchNightFall.Core.Application.ViewModels.FollowerAward;

public class FollowerAwardAddDto : AuditableAddDto
{
    public FollowerAwardAddDto()
    {
        
    }

    public FollowerAwardAddDto(string username, int prize)
    {
        Username = username;
        Prize = prize;
    }

    public string? Username { get; set; }
    public int Prize { get; set; }
}