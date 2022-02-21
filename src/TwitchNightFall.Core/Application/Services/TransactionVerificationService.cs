using TwitchNightFall.Common.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ITransactionVerificationService
{
    Task<Result> VerifyAsync(string paymentId, CancellationToken cancellationToken = new());
}

public class TransactionVerificationService : ITransactionVerificationService
{
    public Task<Result> VerifyAsync(string paymentId, CancellationToken cancellationToken = new())
    {
        return Task.FromResult(Result.WithSuccess(true));
    }
}