using Microsoft.AspNetCore.Mvc;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

[Route("[controller]")]
public class TwitchAccountController : ControllerBase
{
    private readonly ITwitchHelixService _twitchHelixService;

    public TwitchAccountController(ITwitchHelixService twitchHelixService)
    {
        _twitchHelixService = twitchHelixService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> IsTwitchAccountAvailable(string username)
    {
        var isTwitchAccountAvailable = await _twitchHelixService.IsTwitchAccountAvailable(username);

        return Ok(Result.WithSuccess(isTwitchAccountAvailable));
    }
}