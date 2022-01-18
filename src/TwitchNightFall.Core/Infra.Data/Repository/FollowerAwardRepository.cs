using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public class FollowerAwardRepository : RepositoryAsync<FollowerAward>, IFollowerAwardRepository
{
    public FollowerAwardRepository(ApplicationDbContext context) : base(context)
    {
    }
}