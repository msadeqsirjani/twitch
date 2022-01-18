using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TwitchNightFall.Core.Application.ViewModels;

namespace TwitchNightFall.Core.Application.Services
{
    public interface ITwitchHelixService
    {
        Task<TwitchAccountData?> GetTwitchAccountData(string username, CancellationToken cancellationToken = new());
        Task<bool> IsTwitchAccountAvailable(string username, CancellationToken cancellationToken = new());
    }

    public class TwitchHelixService : ITwitchHelixService
    {
        private readonly HttpClient _client;
        private readonly TwitchSetting _options;

        public TwitchHelixService(IHttpClientFactory httpClientFactory, IOptions<TwitchSetting> options)
        {
            _client = httpClientFactory.CreateClient();
            _options = options.Value;
        }

        public async Task<TwitchAccountData?> GetTwitchAccountData(string username, CancellationToken cancellationToken = new())
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

            var data = JsonConvert.DeserializeObject<TwitchAccountViewModel>(body);

            return data.Data.FirstOrDefault();
        }

        public async Task<bool> IsTwitchAccountAvailable(string username, CancellationToken cancellationToken = new())
        {
            return await GetTwitchAccountData(username, cancellationToken) != null;
        }
    }
}
