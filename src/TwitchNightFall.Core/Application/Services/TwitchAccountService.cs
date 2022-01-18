using Microsoft.Extensions.Options;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services
{
    public interface ITwitchAccountService : IServiceAsync<TwitchAccount>
    {
        Task<(Guid, bool)> InsertIfNotExistsAsync(string username, CancellationToken cancellationToken = new());
    }

    public class TwitchAccountService : ServiceAsync<TwitchAccount>, ITwitchAccountService
    {
        public TwitchAccountService(IRepositoryAsync<TwitchAccount> repository) : base(repository)
        {
        }


        public async Task<(Guid, bool)> InsertIfNotExistsAsync(string username, CancellationToken cancellationToken = new())
        {
            var twitchAccount = new TwitchAccount(username);

            if (await Repository.ExistsAsync(x => x.Username == username, cancellationToken))
            {
                twitchAccount = await Repository.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

                return (TwitchAccountId: twitchAccount!.Id, IsGiftEnabled: false);
            }

            await Repository.AddAsync(twitchAccount, cancellationToken);

            return (TwitchAccountId: twitchAccount.Id, IsGiftEnabled: true);
        }
    }
}
