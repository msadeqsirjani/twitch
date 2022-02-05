using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Domain.Repository;

public interface ISubscriptionRepository : IRepositoryAsync<Subscription>
{
}