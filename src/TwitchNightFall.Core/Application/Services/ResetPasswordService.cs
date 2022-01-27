using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface IResetPasswordService : IServiceAsync<ResetPassword>
{
    Task InsertAsync(ResetPassword resetPassword, CancellationToken cancellationToken = new());
    Task<Result> ShowTwitchAsync(string singleUseCode, CancellationToken cancellationToken = new());
}

public class ResetPasswordService : ServiceAsync<ResetPassword>, IResetPasswordService
{
    private readonly IUnitOfWorkAsync _unitOfWorkAsync;
    private readonly ITwitchService _twitchService;

    public ResetPasswordService(IRepositoryAsync<ResetPassword> repository, IUnitOfWorkAsync unitOfWorkAsync, ITwitchService twitchService) : base(repository)
    {
        _unitOfWorkAsync = unitOfWorkAsync;
        _twitchService = twitchService;
    }

    public async Task InsertAsync(ResetPassword resetPassword, CancellationToken cancellationToken = new())
    {
        await Repository.AddAsync(resetPassword, cancellationToken);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);
    }

    public async Task<Result> ShowTwitchAsync(string singleUseCode, CancellationToken cancellationToken = new())
    {
        var resetPassword = await Repository.FirstOrDefaultAsync(x => x.SingleUseCode == singleUseCode && x.Expiry >= DateTime.UtcNow.AddMinutes(5), cancellationToken);

        if (resetPassword == null)
            return Result.WithException("کدی با چنین مشخصاتی یافت نشد");

        var twitch = await _twitchService.FirstOrDefaultAsync(x => x.Email == resetPassword.Email, cancellationToken);

        if (twitch == null)
            return Result.WithException("کدی با چنین مشخصاتی یافت نشد");

        await Repository.DeleteAsync(resetPassword.Id, cancellationToken);

        await _unitOfWorkAsync.SaveChangesAsync(cancellationToken);

        return Result.WithSuccess(twitch.Id);
    }
}