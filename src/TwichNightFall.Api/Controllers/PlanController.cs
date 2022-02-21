using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

public class PlanController : ApplicationController
{
    private readonly IPlanService _planService;

    public PlanController(IPlanService planService)
    {
        _planService = planService;
    }

    /// <summary>
    /// Receive purchase subscription information
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Other)]
    public async Task<IActionResult> ShowPlans([FromQuery] GridifyQuery request)
    {
        var twitchId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        var result = await _planService.ShowPlansAsync(request, new Guid(twitchId!));

        return Ok(result);
    }
}