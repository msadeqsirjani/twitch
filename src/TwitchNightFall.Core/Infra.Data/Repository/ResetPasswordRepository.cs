using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public class ResetPasswordRepository : RepositoryAsync<ResetPassword>, IResetPasswordRepository
{
    public ResetPasswordRepository(ApplicationDbContext context) : base(context)
    {
    }
}