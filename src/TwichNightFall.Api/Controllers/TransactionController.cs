using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

public class TransactionController : BaseController
{
    private readonly ITransactionVerificationService _transactionVerificationService;

    public TransactionController(ITransactionVerificationService transactionVerificationService)
    {
        _transactionVerificationService = transactionVerificationService;
    }
}