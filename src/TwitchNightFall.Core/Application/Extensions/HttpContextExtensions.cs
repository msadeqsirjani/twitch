using Microsoft.AspNetCore.Http;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Common.Exceptions;

namespace TwitchNightFall.Core.Application.Extensions;

public static class HttpContextExtensions
{
    public static string GetAuthenticationToken(this HttpContext context)
    {
        var authorizationHeader = context.Request.Headers["Authorization"].ToString();

        var token = string.Empty;

        if (authorizationHeader != null && string.IsNullOrEmpty(authorizationHeader) &&
            authorizationHeader.StartsWith("Bearer ")) return token;

        token = authorizationHeader?["Bearer ".Length..];

        return token ?? throw new UnAuthorizedException(Statement.UnAuthorized);
    }
}