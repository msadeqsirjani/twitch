using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Core.Application.ViewModels.Forgiveness;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IForgivenessService : IServiceAsync<Forgiveness>
{
    Task AddAward(Guid twitchAccountId, int prize, CancellationToken cancellationToken = new());
}

public class ForgivenessService : ServiceAsync<Forgiveness>, IForgivenessService
{
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;
    private readonly ITwitchService _twitchService;
    private readonly IValidator<ForgivenessAddDto> _validator;
    private readonly TwitchSetting _options;

    public ForgivenessService(IRepositoryAsync<Forgiveness> repository, IUnitOfWorkAsync unitOfWorkAsync, IOptions<TwitchSetting> options, IValidator<ForgivenessAddDto> validator, ITwitchService twitchService) : base(repository)
    {
        _unitOfWorkAsync = unitOfWorkAsync;
        _validator = validator;
        _twitchService = twitchService;
        _options = options.Value;
    }

    public async Task AddAward(Guid twitchAccountId, int prize, CancellationToken cancellationToken = new())
    {
        var validation =  await _validator.ValidateAsync(new ForgivenessAddDto(prize), cancellationToken);
        if (!validation.IsValid)
            throw new MessageException(validation.Errors.FirstOrDefault()!.ErrorMessage);

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
}