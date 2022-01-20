using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _administratorService.LoginAsync(username, password);

            return Ok(Result.WithSuccess(result));
        }
    }
}
