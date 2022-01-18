using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchNightFall.Core.Application.ViewModels;

public class TwitchSetting
{
    public string? TwitchUrl { get; set; }
    public string? AccessToken { get; set; }
    public string? ClientId { get; set; }
    public int FollowerBoundary { get; set; }
    public int FollowerGift { get; set; }
}