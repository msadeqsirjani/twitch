using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;

namespace TwitchNightFall.Core.Infra.Data.Repository;

public class TransactionRepository : RepositoryAsync<Transaction>, ITransactionRepository
{
    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
    }
}