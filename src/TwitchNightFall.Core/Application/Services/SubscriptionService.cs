using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ISubscriptionService : IServiceAsync<Subscription>
{
    Task<Subscription?> GetSubscriptionAsync(Expression<Func<Subscription, bool>> predicate,
        CancellationToken cancellationToken = new());
}

public class SubscriptionService : ServiceAsync<Subscription>, ISubscriptionService
{
    public SubscriptionService(IRepositoryAsync<Subscription> repository) : base(repository)
    {
    }

    public async Task<Subscription?> GetSubscriptionAsync(Expression<Func<Subscription, bool>> predicate,
        CancellationToken cancellationToken = new())
    {
        return await Repository.Queryable()
            .Include(x => x.Plan)
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}