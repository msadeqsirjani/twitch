using System.Security.Claims;
using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Core.Application.Services;
using TwitchNightFall.Core.Application.ViewModels.Administrator;

namespace TwitchNightFall.Api.Controllers;

public class AdministratorController : ApplicationController
{
    private readonly IAdministratorService _administratorService;
    private readonly ITwitchService _twitchService;
    private readonly IForgivenessService _forgivenessService;
    private readonly ITransactionService _transactionService;

    public AdministratorController(IAdministratorService administratorService, ITwitchService twitchService, IForgivenessService forgivenessService, ITransactionService transactionService)
    {
        _administratorService = administratorService;
        _twitchService = twitchService;
        _forgivenessService = forgivenessService;
        _transactionService = transactionService;
    }

    /// <summary>
    /// Admin login
    /// </summary>
    /// <param name="username">Admin username</param>
    /// <param name="password">Admin Password</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn(string username, string password)
    {
        var result = await _administratorService.SignInAsync(username, password);

        return Ok(result);
    }

    /// <summary>
    /// Add new admin to the system
    /// </summary>
    /// <param name="administrator"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpPost]
    [Authorize(Policy = JwtService.Administrator)]
    public async Task<IActionResult> AddAdministrator(AdministratorDto administrator)
    {
        var administratorId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        administrator.CreatedBy = Guid.Parse(administratorId!);

        var result = await _administratorService.AddAdministrator(administrator);

        return Ok(result);
    }

    /// <summary>
    /// View admin profile
    /// </summary>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Administrator)]
    public async Task<IActionResult> ShowAdminProfile()
    {
        var administratorId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        var result = await _administratorService.ShowProfileAsync(Guid.Parse(administratorId!), HttpContext);

        return Ok(result);
    }

    /// <summary>
    /// Edit admin profile
    /// </summary>
    /// <param name="administrator">Input model for editing admin profile</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpPost]
    [Authorize(Policy = JwtService.Administrator)]
    public async Task<IActionResult> SaveAdminProfile(AdministratorDto administrator)
    {
        var administratorId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        administrator.Id = Guid.Parse(administratorId!);

        var result = await _administratorService.SaveProfileAsync(administrator);

        return Ok(result);
    }

    /// <summary>
    /// View Twitch page info
    /// </summary>
    /// <param name="username">Username Twitch participant in the lottery</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Administrator)]
    public async Task<IActionResult> ShowTwitchProfile(string username)
    {
        var result = await _twitchService.ShowTwitchProfile(username);

        return Ok(Result.WithSuccess(result!));
    }

    /// <summary>
    /// View the information of the people who participated in the lottery during the day and show the number of followers who won  
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Paging<>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Administrator)]
    public IActionResult ShowDetail([FromQuery] GridifyQuery request)
    {
        var result = _forgivenessService.ShowDetail(request);

        return Ok(result);
    }

    /// <summary>
    /// History of participant lottery results records
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Paging<>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Administrator)]
    public IActionResult ShowHistory([FromQuery] GridifyQuery request)
    {
        var result = _forgivenessService.ShowHistory(request);

        return Ok(result);
    }

    /// <summary>
    /// By calling this service and giving the lottery ID, the number of followers obtained will increase.
    /// </summary>
    /// <param name="forgivenessId"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Administrator)]
    public async Task<IActionResult> Complete(Guid forgivenessId)
    {
        var administratorId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        var result = await _forgivenessService.CompleteAsync(forgivenessId, Guid.Parse(administratorId!));

        return Ok(result);
    }

    /// <summary>
    /// View all payments made
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Administrator)]
    public IActionResult ShowTransaction([FromQuery] GridifyQuery request)
    {
        var result = _transactionService.ShowTransaction(request);

        return Ok(result);
    }
}