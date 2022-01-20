using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TwitchNightFall.Core.Application.ViewModels;

namespace TwitchNightFall.Core.Application.Services;

public interface IJwtService
{
    Task<JwtTokenDto> GenerateJwtToken(Guid userId, string username);
}

public class JwtService : IJwtService
{
    private readonly JwtSetting _options;

    public JwtService(IOptions<JwtSetting> options)
    {
        _options = options.Value;
    }

    public Task<JwtTokenDto> GenerateJwtToken(Guid userId, string username)
    {
        var key = Encoding.ASCII.GetBytes(_options.IssuerSigningKey);
        var notBefore = DateTime.UtcNow;
        var expires = DateTime.UtcNow.AddDays(1);
        var expiry = expires.ToEpochTimeSpan().TotalSeconds.ToInt32();
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, username),
            new(ClaimTypes.NameIdentifier, userId.ToString()),
            new(ClaimTypes.Expiration, expiry.ToString(CultureInfo.InvariantCulture))
        };

        var jwtToken = new JwtSecurityToken(_options.ValidIssuer, _options.ValidAudience, claims, notBefore, expires,
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        var jwtTokenDto = new JwtTokenDto(userId, username, token, expiry);

        return Task.FromResult(jwtTokenDto);
    }
}