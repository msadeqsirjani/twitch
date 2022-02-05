using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers
{
    public class SubscriptionController : BaseController
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        /// <summary>
        /// دریافت اطلاعات اشتراک خرید
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
        [HttpGet]
        [Authorize]
        public IActionResult GetSubscriptions([FromQuery] GridifyQuery request)
        {
            var result = _subscriptionService.GetSubscriptions(request);

            return Ok(result);
        }
    }
}
