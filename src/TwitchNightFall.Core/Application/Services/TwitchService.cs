using FluentValidation;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Core.Application.ViewModels.Twitch;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ITwitchService : IServiceAsync<Twitch>
{
    Task<Result> SignUpAsync(TwitchAddDto twitchAddDto, CancellationToken cancellationToken = new());
    Task<Result> SingInAsync(string username, string password, CancellationToken cancellationToken = new());
    Task<TwitchHelixInfo?> ShowTwitchProfile(string username, CancellationToken cancellationToken = new());
    Task<bool> IsAvailableTwitch(string username, CancellationToken cancellationToken = new());
}

public class TwitchService : ServiceAsync<Twitch>, ITwitchService
{
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;
    private readonly IValidator<TwitchAddDto> _validator;
    private readonly IJwtService _jwtService;
    private readonly HttpClient _client;
    private readonly TwitchSetting _options;

    public TwitchService(IRepositoryAsync<Twitch> repository,
        IUnitOfWorkAsync unitOfWorkAsync,
        IHttpClientFactory httpClientFactory,
        IOptions<TwitchSetting> options, IValidator<TwitchAddDto> validator, IJwtService jwtService) : base(repository)
    {
        _unitOfWorkAsync = unitOfWorkAsync;
        _validator = validator;
        _jwtService = jwtService;
        _client = httpClientFactory.CreateClient();
        _options = options.Value;
    }

    public async Task<Result> SignUpAsync(TwitchAddDto twitchAddDto, CancellationToken cancellationToken = new())
    {
        var validation = await _validator.ValidateAsync(twitchAddDto, cancellationToken);

        if (!validation.IsValid)
            throw new MessageException(validation.Errors.FirstOrDefault()?.ErrorMessage);

        var twitch = await Repository.FirstOrDefaultAsync(x => x.Username == twitchAddDto.Username, cancellationToken);

        if (twitch != null)
            throw new MessageException("نام کاربری تکراری می باشد");

        if (!await IsAvailableTwitch(twitchAddDto.Username!, cancellationToken))
            throw new MessageException("نام کاربری معادلی در توییچ یافت نشد");

        twitch = new Twitch(twitchAddDto.Username!, twitchAddDto.Email!, Security.Encrypt(twitchAddDto.Password!));

        await Repository.AddAsync(twitch, cancellationToken);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

        var jwtToken = await _jwtService.GenerateJwtToken(twitch.Id, twitch.Username, false);

        return Result.WithSuccess(jwtToken);
    }

    public async Task<Result> SingInAsync(string username, string password, CancellationToken cancellationToken = new())
    {
        var twitch = await Repository.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

        if(twitch == null)
            return Result.WithSuccess("نام کاربری یافت نشد");

        if (!Security.Decrypt(twitch.Password!).Equals(password))
            throw new MessageException("رمز عبور نادرست می باشد");

        var jwtTokenDto = await _jwtService.GenerateJwtToken(twitch.Id, twitch.Username!, false);

        return Result.WithSuccess(jwtTokenDto);
    }

    public async Task<TwitchHelixInfo?> ShowTwitchProfile(string username, CancellationToken cancellationToken = new())
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_options.TwitchUrl + username),
            Headers =
            {
                { "Authorization", "Bearer " +  _options.AccessToken },
                { "Client-Id", _options.ClientId },
            },
        };

        using var response = await _client.SendAsync(request, cancellationToken);

        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        var data = JsonConvert.DeserializeObject<TwitchViewModel>(body);

        return data.Data.FirstOrDefault();
    }

    public async Task<bool> IsAvailableTwitch(string username, CancellationToken cancellationToken = new())
    {
        return await ShowTwitchProfile(username, cancellationToken) != null;
    }
}