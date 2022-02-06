namespace TwitchNightFall.Core.Application.Services;

public interface ITransactionVerificationService
{
    Task<bool> VerifyAsync(CancellationToken cancellationToken = new());
}

public class TransactionVerificationService : ITransactionVerificationService
{
    public Task<bool> VerifyAsync(CancellationToken cancellationToken = new())
    {
        return Task.FromResult(true);
    }
}