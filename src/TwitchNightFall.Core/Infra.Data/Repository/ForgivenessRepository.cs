using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public class ForgivenessRepository : RepositoryAsync<Forgiveness>, IForgivenessRepository
{
    public ForgivenessRepository(ApplicationDbContext context) : base(context)
    {
    }
}