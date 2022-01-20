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
    IEnumerable<MonitorTwitch> MonitorAsync(GridRequest request);
    Task CheckAsync(Guid id, CancellationToken cancellationToken = new());
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

    public IEnumerable<MonitorTwitch> MonitorAsync(GridRequest request)
    {
        var twitches = Repository.Queryable(false)
            .Include(x => x.Twitch)
            .Select(x => x.TwitchId)
            .Distinct()
            .Select(twitchId => new
            {
                TwitchId = twitchId,
                Forgiveness = Repository.Queryable(false)
                    .Where(y => y.TwitchId == twitchId && EF.Functions.DateDiffDay(y.CreatedAt, DateTime.UtcNow) == 0)
                    .OrderByDescending(y => y.IsChecked)
                    .ThenByDescending(x => x.CreatedAt)
                    .ThenByDescending(y => y.ModifiedAt)
                    .ToList()
            })
            .Select(x => new MonitorTwitch
            {
                Id = x.Forgiveness.Single().Id,
                TwitchId = x.TwitchId,
                Username = x.Forgiveness.Single().Twitch.Username,
                TotalPrize = x.Forgiveness.Sum(y => y.Prize),
                Forgiveness = x.Forgiveness
            })
            .AsQueryable()
            .ApplyFiltering(request)
            .ApplyOrdering(request)
            .ApplyPaging(request);

        return twitches;

    }


    public async Task CheckAsync(Guid id ,CancellationToken  cancellationToken = new())
    {
        var forgiveness = await Repository.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (forgiveness == null)
            throw new MessageException("شناسه قرعه کشی موجود نمی باشد");

        forgiveness.IsChecked = true;

        Repository.Attach(forgiveness);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);
    }
}