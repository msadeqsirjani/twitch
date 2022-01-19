using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services
{
    public interface ITwitchService : IServiceAsync<Twitch>
    {
        Task<Guid> AddAsync(string username, CancellationToken cancellationToken = new());
    }

    public class TwitchService : ServiceAsync<Twitch>, ITwitchService
    {
        private readonly ITwitchHelixService _twitchHelixService;

        public TwitchService(IRepositoryAsync<Twitch> repository, ITwitchHelixService twitchHelixService) : base(repository)
        {
            _twitchHelixService = twitchHelixService;
        }


        public async Task<Guid> AddAsync(string username, CancellationToken cancellationToken = new())
        {
            var twitchAccount = await Repository.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

            if (twitchAccount != null)
                return twitchAccount.Id;

            if (!await _twitchHelixService.IsTwitchAccountAvailable(username, cancellationToken))
                throw new MessageException("نام کاربری معادلی در توییچ یافت نشد");



            twitchAccount = new Twitch(username);

            await Repository.AddAsync(twitchAccount, cancellationToken);

            return twitchAccount.Id;
        }
    }
}
