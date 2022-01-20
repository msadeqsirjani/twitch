using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public AdministratorController(IAdministratorService administratorService, ITwitchService twitchService)
        {
            _administratorService = administratorService;
            _twitchService = twitchService;
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
        public async Task<IActionResult> ShowProfile()
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
        public async Task<IActionResult> SaveProfile([FromBody] Administrator administrator)
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
        public async Task<IActionResult> ShowTwitchDetail(string username)
        {
            var result = await _twitchService.GetTwitchAccountData(username);

            return Ok(Result.WithSuccess(result!));
        }
    }
}
