using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public class AdministratorRepository : RepositoryAsync<Administrator>, IAdministratorRepository
{
    public AdministratorRepository(ApplicationDbContext context) : base(context)
    {
    }
}