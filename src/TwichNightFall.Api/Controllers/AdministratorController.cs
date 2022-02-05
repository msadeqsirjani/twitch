using System.Security.Claims;
using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;
using TwitchNightFall.Core.Application.ViewModels.Administrator;

namespace TwitchNightFall.Api.Controllers;

public class AdministratorController : BaseController
{
    private readonly IAdministratorService _administratorService;
    private readonly ITwitchService _twitchService;
    private readonly IForgivenessService _forgivenessService;

    public AdministratorController(IAdministratorService administratorService, ITwitchService twitchService, IForgivenessService forgivenessService)
    {
        _administratorService = administratorService;
        _twitchService = twitchService;
        _forgivenessService = forgivenessService;
    }

    /// <summary>
    /// ورود ادمین به سیستم
    /// </summary>
    /// <param name="username">نام کاربری ادمین</param>
    /// <param name="password">کلمه عبور ادمین</param>
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
    /// افزودن ادمیت جدید به سیستم
    /// </summary>
    /// <param name="administrator"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAdministrator([FromBody] AdministratorDto administrator)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        administrator.CreatedBy = Guid.Parse(userId!);

        var result = await _administratorService.AddAdministrator(administrator);

        return Ok(result);
    }

    /// <summary>
    /// مشاهده پروفایل ادمین
    /// </summary>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ShowAdminProfile()
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        var result = await _administratorService.ShowProfileAsync(Guid.Parse(userId!), HttpContext);

        return Ok(result);
    }

    /// <summary>
    /// ویرایش پروفایل ادمین
    /// </summary>
    /// <param name="administrator">مدل ورودی جهت ویرایش پروفایل ادمین</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SaveAdminProfile([FromBody] AdministratorDto administrator)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        administrator.Id = Guid.Parse(userId!);

        var result = await _administratorService.SaveProfileAsync(administrator);

        return Ok(result);
    }

    /// <summary>
    /// مشاهده اطلاعات صفحه توییچ
    /// </summary>
    /// <param name="username">نام کاربری توییچ شرکت کننده در قرعه کشی</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ShowTwitchProfile(string username)
    {
        var result = await _twitchService.ShowTwitchProfile(username);

        return Ok(Result.WithSuccess(result!));
    }

    /// <summary>
    /// مشاهده اطلاعات افرادی که در طول روز در قرعه کشی شرکت کرده اند و نمایش تعداد دنبال کنندگانی که برنده به دست آورده اند  
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Paging<>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize]
    public IActionResult ShowDetail([FromQuery] GridifyQuery request)
    {
        var result = _forgivenessService.ShowDetail(request);

        return Ok(result);
    }

    /// <summary>
    /// تاریخچه سوابق نتایج قرعه کشی شرکت کننده
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Paging<>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize]
    public IActionResult ShowHistory([FromQuery] GridifyQuery request)
    {
        var result = _forgivenessService.ShowHistory(request);

        return Ok(result);
    }

    /// <summary>
    /// با صدا زدن این سرویس و دادن شناسه قرعه کشی تعداد دنبال کنندگان به دست آمده به دنبال شوندگان شرکت کننده افزوده می شود
    /// </summary>
    /// <param name="forgivenessId"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Complete(Guid forgivenessId)
    {
        var administrator = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        var result = await _forgivenessService.CompleteAsync(forgivenessId, Guid.Parse(administrator!));

        return Ok(result);
    }
}