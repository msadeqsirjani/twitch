using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services
{
    public interface ITwitchService : IServiceAsync<Twitch>
    {
        Task<Guid> AddAsync(string username, CancellationToken cancellationToken = new());
        Task<TwitchInfo?> GetTwitchAccountData(string username, CancellationToken cancellationToken = new());
        Task<bool> IsTwitchAccountAvailable(string username, CancellationToken cancellationToken = new());
    }

    public class TwitchService : ServiceAsync<Twitch>, ITwitchService
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly HttpClient _client;
        private readonly TwitchSetting _options;

        public TwitchService(IRepositoryAsync<Twitch> repository,
            IUnitOfWorkAsync unitOfWorkAsync,
            IHttpClientFactory httpClientFactory, 
            IOptions<TwitchSetting> options) : base(repository)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _client = httpClientFactory.CreateClient();
            _options = options.Value;
        }

        public async Task<Guid> AddAsync(string username, CancellationToken cancellationToken = new())
        {
            var twitchAccount = await Repository.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

            if (twitchAccount != null)
                return twitchAccount.Id;

            if (!await IsTwitchAccountAvailable(username, cancellationToken))
                throw new MessageException("نام کاربری معادلی در توییچ یافت نشد");

            twitchAccount = new Twitch(username);

            await Repository.AddAsync(twitchAccount, cancellationToken);

            await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

            return twitchAccount.Id;
        }

        public async Task<TwitchInfo?> GetTwitchAccountData(string username, CancellationToken cancellationToken = new())
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

        public async Task<bool> IsTwitchAccountAvailable(string username, CancellationToken cancellationToken = new())
        {
            return await GetTwitchAccountData(username, cancellationToken) != null;
        }
    }
}
