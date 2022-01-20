using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

    /// <summary>
    /// بررسی وجود نام کاربری معادل در توییچ و ایجاد اکانت جهت استفاده از گردونه شانس
    /// </summary>
    /// <param name="username">نام کابری کابر شرکت کننده در قرعه کشی گردونه شانس</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Availability(string username)
    {
        var twitchAccountId = await _twitchService.AddAsync(username);

        return Ok(Result.WithSuccess(twitchAccountId));
    }

    /// <summary>
    /// ذخیره و بررسی گردونه شانس دنبال شوندگان
    /// </summary>
    /// <param name="twitchAccountId">شناسه اکانت های ایجاد شده در مرحله ثببت نام در گردونه شانس</param>
    /// <param name="prize">تعداد دنبال کنندگانی که در این قرعه کشی برنده شده است این عدد تنها بین 1 تا 5 می باشد</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Forgiveness(Guid twitchAccountId, int prize)
    {
        await _forgivenessService.AddAsync(twitchAccountId, prize);

        return Ok(Result.WithSuccess(Statement.Success));
    }
}