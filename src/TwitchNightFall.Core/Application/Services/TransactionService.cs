using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Application.Services;

public interface ITransactionService : IServiceAsync<Transaction>
{

}

public class TransactionService : ServiceAsync<Transaction>, ITransactionService
{
    public TransactionService(IRepositoryAsync<Transaction> repository) : base(repository)
    {
    }
}