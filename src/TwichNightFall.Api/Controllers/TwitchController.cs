using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

public class TwitchController : BaseController
{
    private readonly ITwitchService _twitchService;
    private readonly IForgivenessService _forgivenessService;

    public TwitchController(ITwitchService twitchService, IForgivenessService forgivenessService)
    {
        _twitchService = twitchService;
        _forgivenessService = forgivenessService;
    }

    [HttpGet]
    public async Task<IActionResult> ValidateTwitchAccount(string username)
    {
        var twitchAccountId = await _twitchService.AddAsync(username);

        return Ok(Result.WithSuccess(twitchAccountId));
    }

    [HttpGet]
    public async Task<IActionResult> Forgiveness(Guid twitchAccountId, int prize)
    {
        await _forgivenessService.AddAward(twitchAccountId, prize);

        return Ok(Result.WithSuccess(Statement.Success));
    }
}