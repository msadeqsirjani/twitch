using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public class TwitchAccountRepository : RepositoryAsync<TwitchAccount>, ITwitchAccountRepository
{
    public TwitchAccountRepository(ApplicationDbContext context) : base(context)
    {
    }
}