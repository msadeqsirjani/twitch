using Microsoft.AspNetCore.Mvc;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

public class FollowerAwardController : BaseController
{
    private readonly IFollowerAwardService _followerAwardService;

    public FollowerAwardController(IFollowerAwardService followerAwardService)
    {
        _followerAwardService = followerAwardService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> AwardFollower(string username, int prize)
    {
        await _followerAwardService.AddFollowerAward(username, prize);

        return Ok(Result.WithSuccess(Statement.Success));
    }
}