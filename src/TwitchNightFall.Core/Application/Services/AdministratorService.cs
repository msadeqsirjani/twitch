using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IAdministratorService : IServiceAsync<Administrator>
{
    Task<JwtTokenDto> LoginAsync(string username, string password, CancellationToken cancellationToken = new());
}

public class AdministratorService : ServiceAsync<Administrator>, IAdministratorService
{
    private readonly IJwtService _jwtService;

    public AdministratorService(IRepositoryAsync<Administrator> repository, IJwtService jwtService) : base(repository)
    {
        _jwtService = jwtService;
    }

    public async Task<JwtTokenDto> LoginAsync(string username, string password, CancellationToken cancellationToken = new())
    {
        var administrator = await Repository.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

        if (administrator == null) throw new MessageException("نام کاربری یافت نشد");

        if (!Security.Decrypt(administrator.Password!).Equals(password))
            throw new MessageException("رمز عبور نادرست می باشد");

        return await _jwtService.GenerateJwtToken(administrator.Id, administrator.Username!);
    }
}