using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Core.Application.ViewModels.FollowerAward;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IFollowerAwardService : IServiceAsync<FollowerAward>
{
    Task AddFollowerAward(string username, int prize, CancellationToken cancellationToken = new());
}

public class FollowerAwardService : ServiceAsync<FollowerAward>, IFollowerAwardService
{
    private readonly ITwitchAccountService _twitchAccountService;
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;
    private readonly ITwitchHelixService _twitchHelixService;
    private readonly TwitchSetting _options;
    private readonly IValidator<FollowerAwardAddDto> _validator;

    public FollowerAwardService(IRepositoryAsync<FollowerAward> repository, ITwitchAccountService twitchAccountService, IUnitOfWorkAsync unitOfWorkAsync, ITwitchHelixService twitchHelixService, IOptions<TwitchSetting> options, IValidator<FollowerAwardAddDto> validator) : base(repository)
    {
        _twitchAccountService = twitchAccountService;
        _unitOfWorkAsync = unitOfWorkAsync;
        _twitchHelixService = twitchHelixService;
        _validator = validator;
        _options = options.Value;
    }

    public async Task AddFollowerAward(string username, int prize, CancellationToken cancellationToken = new())
    {
        var validation =  await _validator.ValidateAsync(new FollowerAwardAddDto(username, prize), cancellationToken);
        if (!validation.IsValid)
            throw new MessageException(validation.Errors.FirstOrDefault()!.ErrorMessage);

        if (!(await _twitchHelixService.IsTwitchAccountAvailable(username, cancellationToken)))
            throw new MessageException("اکانت توییچ با چنین مشحصاتی یافت نشد");

        var (twitchAccountId, isGiftEnabled) = await _twitchAccountService.InsertIfNotExistsAsync(username, cancellationToken);

        //if (isGiftEnabled)
        //{
        //    var giftFollowerAward = new FollowerAward(twitchAccountId, _options.FollowerGift);

        //    await Repository.AddAsync(giftFollowerAward, cancellationToken);
        //}

        var followerAward = new FollowerAward(twitchAccountId, prize);

        var now = DateTime.UtcNow;

        var count = await Repository.CountAsync(x =>
            x.TwitchAccountId == twitchAccountId && EF.Functions.DateDiffDay(x.CreatedAt, now) == 0, cancellationToken);

        if (count >= _options.FollowerBoundary)
            throw new MessageException("هر نام کاربری تنها 5 بار می تواند از این امکان استفاده کند");

        await Repository.AddAsync(followerAward, cancellationToken);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);
    }
}