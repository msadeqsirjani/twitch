using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Core.Application.ViewModels.Twitch;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ITwitchService : IServiceAsync<Twitch>
{
    Task<TwitchHelixInfo?> ShowTwitchProfile(string username, CancellationToken cancellationToken = new());
    Task<bool> IsAvailableTwitch(string username, CancellationToken cancellationToken = new());
    Task<Result> GetAccessToken(string username, CancellationToken cancellationToken = new());
    Task<Result> TotalForgivenessCount(Guid id, CancellationToken cancellationToken = new());
}

public class TwitchService : ServiceAsync<Twitch>, ITwitchService
{
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly HttpClient _client;
    private readonly TwitchSetting _options;

    public TwitchService(IRepositoryAsync<Twitch> repository,
        IHttpClientFactory httpClientFactory,
        IOptions<TwitchSetting> options,
        IJwtService jwtService,
        IUnitOfWorkAsync unitOfWork) : base(repository)
    {
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
        _client = httpClientFactory.CreateClient();
        _options = options.Value;
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

    public async Task<Result> GetAccessToken(string username, CancellationToken cancellationToken = new())
    {
        if (!await IsAvailableTwitch(username, cancellationToken))
            return Result.WithMessage($"This username '{username}' doesn't exist in Twitch");

        var twitch = await Repository.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

        if (twitch == null)
        {
            twitch = new Twitch(username);

            Repository.Add(twitch);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        var token = await _jwtService.GenerateJwtToken(twitch.Id, username, false);

        return Result.WithSuccess(token);
    }

    public async Task<Result> TotalForgivenessCount(Guid id, CancellationToken cancellationToken = new CancellationToken())
    {
        var count = await Repository.Queryable(false)
            .Include(x => x.Forgiveness)
            .SelectMany(x => x.Forgiveness)
            .Where(x => !x.IsChecked)
            .Select(x=>x.Prize)
            .SumAsync(cancellationToken);

        return Result.WithSuccess(count);
    }
}