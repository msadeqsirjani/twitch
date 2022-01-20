using Gridify;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IForgivenessService : IServiceAsync<Forgiveness>
{
    Task AddAsync(Guid twitchAccountId, int prize, CancellationToken cancellationToken = new());
    IEnumerable<MonitorTwitch> ShowAsync(GridRequest request);
}

public class ForgivenessService : ServiceAsync<Forgiveness>, IForgivenessService
{
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;
    private readonly ITwitchService _twitchService;
    private readonly TwitchSetting _options;

    public ForgivenessService(IRepositoryAsync<Forgiveness> repository,
        IUnitOfWorkAsync unitOfWorkAsync,
        IOptions<TwitchSetting> options,
        ITwitchService twitchService) : base(repository)
    {
        _unitOfWorkAsync = unitOfWorkAsync;
        _twitchService = twitchService;
        _options = options.Value;
    }

    public async Task AddAsync(Guid twitchAccountId, int prize, CancellationToken cancellationToken = new())
    {
        if (prize is > 5 or < 0)
            throw new MessageException("تعداد فالوور های هدیه داده شده نمی تواند کمتر از 0 و بیشتر از 5 باشد");

        var now = DateTime.UtcNow;

        var count = await Repository.CountAsync(x =>
            x.TwitchId == twitchAccountId && EF.Functions.DateDiffDay(x.CreatedAt, now) == 0, cancellationToken);

        if (count >= _options.FollowerBoundary)
            throw new MessageException("هر نام کاربری تنها 5 بار می تواند از این امکان در روز استفاده کند");

        if (!await _twitchService.ExistsAsync(x => x.Id == twitchAccountId, cancellationToken))
            throw new MessageException("کاربری با چنین شناسه ای یافت نشد");

        var followerAward = new Forgiveness(twitchAccountId, prize);

        await Repository.AddAsync(followerAward, cancellationToken);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);
    }

    public IEnumerable<MonitorTwitch> ShowAsync(GridRequest request)
    {
        var twitches = Repository.Queryable(false)
            .Include(x => x.Twitch)
            .ApplyFiltering(request)
            .ApplyOrdering(request)
            .ApplyPaging(request)
            .Select(x=> new MonitorTwitch()
            {
                Id = x.Id,
                TwitchId = x.TwitchId,
                Username = x.Twitch.Username,
                TotalPrize = x.Prize
            });

        return twitches;

    }
}