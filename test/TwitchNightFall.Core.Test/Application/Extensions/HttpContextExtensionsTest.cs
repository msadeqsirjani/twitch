using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Common.Exceptions;
using TwitchNightFall.Core.Application.Extensions;
using Xunit;

namespace TwitchNightFall.Core.Test.Application.Extensions;

public class HttpContextExtensionsTest
{
    [Fact]
    public void GetAuthenticationToken_ReturnEmptyString()
    {
        var context = new DefaultHttpContext();

        context.Request.Headers.Add("Authorization", new StringValues(""));

        context.GetAuthenticationToken().Should().BeNullOrEmpty();
    }

    [Fact]
    public void GetAuthenticationToken_ReturnValidString()
    {
        const string token = "7803E735-8EBE-4197-894E-10F076D6947D";

        var context = new DefaultHttpContext();

        context.Request.Headers.Add("Authorization", new StringValues($"Bearer {token}"));

        context.GetAuthenticationToken().Should()
            .NotBeNullOrEmpty().And
            .Be(token).And
            .HaveLength(token.Length);
    }

    [Fact]
    public void GetAuthenticationTokenThrowUnauthorized()
    {
        var context = new DefaultHttpContext();

        context.Request.Headers.Add("Authorization", new StringValues($"Bearer "));

        var action = () => context.GetAuthenticationToken();

        action.Should()
            .Throw<UnAuthorizedException>()
            .WithMessage(Statement.UnAuthorized);
    }
}