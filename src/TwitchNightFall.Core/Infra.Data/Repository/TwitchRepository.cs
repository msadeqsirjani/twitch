using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public class TwitchRepository : RepositoryAsync<Twitch>, ITwitchRepository
{
    public TwitchRepository(ApplicationDbContext context) : base(context)
    {
    }
}