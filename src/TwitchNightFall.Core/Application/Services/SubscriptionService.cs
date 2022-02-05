using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ISubscriptionService : IServiceAsync<Subscription>
{

}

public class SubscriptionService : ServiceAsync<Subscription>, ISubscriptionService
{
    public SubscriptionService(IRepositoryAsync<Subscription> repository) : base(repository)
    {
    }
}