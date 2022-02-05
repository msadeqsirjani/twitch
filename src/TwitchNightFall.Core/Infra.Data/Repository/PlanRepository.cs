using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public class PlanRepository : RepositoryAsync<Plan>, IPlanRepository
{
    public PlanRepository(ApplicationDbContext context) : base(context)
    {
    }
}