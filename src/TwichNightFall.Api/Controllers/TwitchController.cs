using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

public class TwitchController : ApplicationController
{
    private readonly ITwitchService _twitchService;
    private readonly IForgivenessService _forgivenessService;

    public TwitchController(ITwitchService twitchService, IForgivenessService forgivenessService)
    {
        _twitchService = twitchService;
        _forgivenessService = forgivenessService;
    }

    /// <summary>
    /// Check the existence of an equivalent username in Twitch and create an account to use the chance wheel
    /// </summary>
    /// <param name="username">Username of the lucky participant in the lottery</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Availability(string username)
    {
        var result = await _twitchService.IsAvailableTwitch(username);

        return Ok(Result.WithSuccess(result));
    }

    /// <summary>
    /// Request to create an account and receive a token
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> AccessToken(string username)
    {
        return Ok(await _twitchService.GetAccessToken(username));
    }

    /// <summary>
    /// Save and check the chance wheel of the followers
    /// </summary>
    /// <param name="prize">The number of followers that has won this lottery is only between 1 and 5</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Other)]
    public async Task<IActionResult> Forgiveness(int prize)
    {
        var twitchId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        var result = await _forgivenessService.Forgiveness(new Guid(twitchId!), prize);

        return Ok(result);
    }

    /// <summary>
    /// Get the total count of unchecked forgiveness followers
    /// </summary>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Other)]
    public async Task<IActionResult> TotalForgivenessCount()
    {
        var twitchId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        return Ok(await _twitchService.TotalForgivenessCount(new Guid(twitchId!)));
    }
}