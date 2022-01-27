using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;
using TwitchNightFall.Core.Application.ViewModels.Twitch;

namespace TwitchNightFall.Api.Controllers;

[Route("api/[controller]/[action]")]
public class TwitchController : ControllerBase
{
    private readonly ITwitchService _twitchService;
    private readonly IForgivenessService _forgivenessService;
    private readonly IMailService _mailService;
    private readonly IResetPasswordService _resetPasswordService;

    public TwitchController(ITwitchService twitchService, IForgivenessService forgivenessService, IMailService mailService, IResetPasswordService resetPasswordService)
    {
        _twitchService = twitchService;
        _forgivenessService = forgivenessService;
        _mailService = mailService;
        _resetPasswordService = resetPasswordService;
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
        var result = await _twitchService.IsAvailableTwitch(username);

        return Ok(Result.WithSuccess(result));
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
    [Authorize]
    public async Task<IActionResult> Forgiveness(Guid twitchAccountId, int prize)
    {
        var result = await _forgivenessService.Forgiveness(twitchAccountId, prize);

        return Ok(result);
    }

    /// <summary>
    /// ثبت نام کاربر
    /// </summary>
    /// <param name="twitchAddDto"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] TwitchAddDto twitchAddDto)
    {
        var result = await _twitchService.SignUpAsync(twitchAddDto);

        return Ok(result);
    }

    /// <summary>
    /// ورود کاربر
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn(string username, string password)
    {
        var result = await _twitchService.SingInAsync(username, password);

        return Ok(result);
    }

    /// <summary>
    /// بازیابی رمز عبور
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(string email)
    {
        await _mailService.Send(email);

        return Ok(Result.WithSuccess(Statement.Success));
    }

    /// <summary>
    /// تایید بازیابی رمز عبور
    /// </summary>
    /// <param name="singleUseCode"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmResetPassword(string singleUseCode)
    {
        var result = await _resetPasswordService.ShowTwitchAsync(singleUseCode);

        return Ok(result);
    }
}