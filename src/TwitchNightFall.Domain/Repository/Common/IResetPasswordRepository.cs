using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public interface IResetPasswordRepository : IRepository<ResetPassword>
{
}