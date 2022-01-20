using System.Security.Claims;
using Gridify;
using Gridify.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class AdministratorController : ControllerBase
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
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _administratorService.LoginAsync(username, password);

            return Ok(Result.WithSuccess(result));
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

            return Ok(Result.WithSuccess(result));
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
        public async Task<IActionResult> SaveAdminProfile([FromBody] Administrator administrator)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            administrator.Id = Guid.Parse(userId!);

            await _administratorService.SaveProfileAsync(administrator);

            return Ok(Result.WithSuccess(Statement.Success));
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
        [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
        [HttpPost]
        [Authorize]
        public IActionResult Monitor([FromBody] GridRequest request)
        {
            var result = _forgivenessService.Monitor(request);

            return Ok(Result.WithSuccess(result));
        }

        /// <summary>
        /// تاریخچه سوابق نتایج قرعه کشی شرکت کننده
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
        [HttpPost]
        [Authorize]
        public IActionResult MoreDetails([FromBody] GridRequest request)
        {
            var result = _forgivenessService.MoreDetails(request);

            return Ok(result);
        }

        /// <summary>
        /// با صدا زدن این سرویس و دادن شناسه قرعه کشی تعداد دنبال کنندگان به دست آمده به دنبال شوندگان شرکت کننده افزوده می شود
        /// </summary>
        /// <param name="forgivenessId"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(ServiceResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Check(Guid forgivenessId)
        {
            await _forgivenessService.CheckAsync(forgivenessId);

            return Ok(Result.WithSuccess(Statement.Success));
        }
    }
}
