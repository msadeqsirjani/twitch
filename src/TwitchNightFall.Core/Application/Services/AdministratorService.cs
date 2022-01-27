using FluentValidation;
using Microsoft.AspNetCore.Http;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels.Administrator;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IAdministratorService : IServiceAsync<Administrator>
{
    Task<Result> SignInAsync(string username, string password, CancellationToken cancellationToken = new());
    Task<Result> AddAdministrator(AdministratorDto administratorDto, CancellationToken cancellationToken = new());
    Task<Result> ShowProfileAsync(Guid id, HttpContext context, CancellationToken cancellationToken = new());
    Task<Result> SaveProfileAsync(AdministratorDto administratorDto, CancellationToken cancellationToken = new());
}

public class AdministratorService : ServiceAsync<Administrator>, IAdministratorService
{
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;
    private readonly IValidator<AdministratorDto> _validator;

    public AdministratorService(IRepositoryAsync<Administrator> repository, IJwtService jwtService, IUnitOfWorkAsync unitOfWorkAsync, IValidator<AdministratorDto> validator) : base(repository)
    {
        _jwtService = jwtService;
        _unitOfWorkAsync = unitOfWorkAsync;
        _validator = validator;
    }

    public async Task<Result> SignInAsync(string username, string password, CancellationToken cancellationToken = new())
    {
        var administrator = await Repository.FirstOrDefaultAsync(x => x.Username == username && x.IsActive, cancellationToken);

        if (administrator == null) throw new MessageException("نام کاربری یافت نشد");

        if (!Security.Decrypt(administrator.Password!).Equals(password))
            throw new MessageException("رمز عبور نادرست می باشد");

        var jwtTokenDto = await _jwtService.GenerateJwtToken(administrator.Id, administrator.Username!, true);

        return Result.WithSuccess(jwtTokenDto);
    }

    public async Task<Result> AddAdministrator(AdministratorDto administratorDto, CancellationToken cancellationToken = new())
    {
        var validation = await _validator.ValidateAsync(administratorDto, cancellationToken);
        if (!validation.IsValid)
            throw new MessageException(validation.Errors.FirstOrDefault()?.ErrorMessage!);

        var administrator = new Administrator
        {
            Id = Guid.NewGuid(),
            Username = administratorDto.Username,
            Password = Security.Encrypt(administratorDto.Password!),
            Firstname = administratorDto.Firstname,
            Lastname = administratorDto.Lastname,
            CreatedBy = administratorDto.CreatedBy,
            IsActive = true,
            ProfileImageUrl = administratorDto.ProfileImageUrl
        };

        await Repository.AddAsync(administrator, cancellationToken);
        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

        return Result.WithSuccess(Statement.Success);
    }

    public async Task<Result> ShowProfileAsync(Guid id, HttpContext context, CancellationToken cancellationToken = new())
    {
        var administrator = await Repository.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (administrator == null)
            throw new MessageException("حسابی با چنین مشخصاتی یافت نشد");

        var profileImageUrl = string.IsNullOrEmpty(administrator.ProfileImageUrl)
            ? null
            : (context.Request.IsHttps ? "https" : "http") + $"://{context.Request.Host}/File/Download?filename={administrator.ProfileImageUrl}";

        var administratorDto = new Administrator(administrator.Firstname, administrator.Lastname, profileImageUrl,
            administrator.Username, Security.Decrypt(administrator.Password!))
        {
            Id = administrator.Id,
            CreatedAt = administrator.CreatedAt,
            ModifiedAt = administrator.ModifiedAt,
            IsActive = administrator.IsActive,
            CreatedBy = administrator.CreatedBy
        };

        return Result.WithSuccess(administratorDto);
    }

    public async Task<Result> SaveProfileAsync(AdministratorDto administratorDto, CancellationToken cancellationToken = new())
    {
        var validation = await _validator.ValidateAsync(administratorDto, cancellationToken);
        if (!validation.IsValid)
            throw new MessageException(validation.Errors.FirstOrDefault()?.ErrorMessage!);

        var administrator = await Repository.FirstOrDefaultAsync(x => x.Id == administratorDto.Id && x.IsActive, cancellationToken);

        if (administrator == null)
            throw new MessageException("حسابی با چنین مشخصاتی یافت نشد");

        administrator.Username = administratorDto.Username;
        administrator.Password = Security.Encrypt(administratorDto.Password!);
        administrator.Firstname = administratorDto.Firstname;
        administrator.Lastname = administratorDto.Lastname;
        administrator.ProfileImageUrl = administratorDto.ProfileImageUrl;

        Repository.Attach(administrator);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

        return Result.WithSuccess(Statement.Success);
    }
}