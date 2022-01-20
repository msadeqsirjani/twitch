using System.Security.Cryptography.X509Certificates;
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
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;

    public AdministratorService(IRepositoryAsync<Administrator> repository, IJwtService jwtService, IUnitOfWorkAsync unitOfWorkAsync) : base(repository)
    {
        _jwtService = jwtService;
        _unitOfWorkAsync = unitOfWorkAsync;
    }

    public async Task<JwtTokenDto> LoginAsync(string username, string password, CancellationToken cancellationToken = new())
    {
        var administrator = await Repository.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

        if (administrator == null) throw new MessageException("نام کاربری یافت نشد");

        if (!Security.Decrypt(administrator.Password!).Equals(password))
            throw new MessageException("رمز عبور نادرست می باشد");

        return await _jwtService.GenerateJwtToken(administrator.Id, administrator.Username!);
    }

    public async Task<Administrator> ShowProfileAsync(Guid id, CancellationToken cancellationToken = new())
    {
        var administrator = await Repository.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (administrator == null)
            throw new MessageException("حسابی با چنین مشخصاتی یافت نشد");

        return new Administrator(administrator.Firstname, administrator.Lastname, administrator.ProfileImageUrl,
            administrator.Username, Security.Decrypt(administrator.Password!))
        {
            Id = administrator.Id,
            CreatedAt = administrator.CreatedAt,
            ModifiedAt = administrator.ModifiedAt
        };
    }

    public async Task AttachProfileAsync(Administrator administratorDto, CancellationToken cancellationToken = new())
    {
        var administrator = await Repository.FirstOrDefaultAsync(x => x.Id == administratorDto.Id, cancellationToken);

        if (administrator == null)
            throw new MessageException("حسابی با چنین مشخصاتی یافت نشد");

        administrator.Username = administratorDto.Username;
        administrator.Password = Security.Encrypt(administratorDto.Password!);
        administrator.Firstname = administratorDto.Firstname;
        administrator.Lastname = administratorDto.Lastname;
        administrator.ProfileImageUrl = administratorDto.ProfileImageUrl;

        Repository.Attach(administrator);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);
    }
}