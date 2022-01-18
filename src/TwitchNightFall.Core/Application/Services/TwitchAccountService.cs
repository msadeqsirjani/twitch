using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services
{
    public interface ITwitchAccountService : IServiceAsync<TwitchAccount>
    {

    }

    public class TwitchAccountService : ServiceAsync<TwitchAccount>, ITwitchAccountService
    {
        public TwitchAccountService(IRepositoryAsync<TwitchAccount> repository) : base(repository)
        {
        }
    }
}
