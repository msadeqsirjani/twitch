using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

[Route("[controller]/[action]")]
public class TwitchController : ControllerBase
{
    private readonly ITwitchService _twitchService;
    private readonly IForgivenessService _forgivenessService;

    public TwitchController(ITwitchService twitchService, IForgivenessService forgivenessService)
    {
        _twitchService = twitchService;
        _forgivenessService = forgivenessService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Availability(string username)
    {
        var twitchAccountId = await _twitchService.AddAsync(username);

        return Ok(Result.WithSuccess(twitchAccountId));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Forgiveness(Guid twitchAccountId, int prize)
    {
        await _forgivenessService.AddAsync(twitchAccountId, prize);

        return Ok(Result.WithSuccess(Statement.Success));
    }

    [HttpPost]
    //[Authorize]
    public IActionResult Monitoring([FromBody] GridRequest request)
    {
        var twitches = _forgivenessService.ShowAsync(request); 

        return Ok(Result.WithSuccess(twitches));
    }
}