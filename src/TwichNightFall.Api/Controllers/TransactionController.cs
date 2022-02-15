using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using TwitchNightFall.Core.Application.Services;
using TwitchNightFall.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using TwitchNightFall.Core.Application.Common;

namespace TwitchNightFall.Api.Controllers;

public class TransactionController : ApplicationController
{
    private readonly ITransactionVerificationService _transactionVerificationService;
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionVerificationService transactionVerificationService, ITransactionService transactionService)
    {
        _transactionVerificationService = transactionVerificationService;
        _transactionService = transactionService;
    }

    /// <summary>
    /// تاییدیه پرداخت
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Verify(string paymentId)
    {
        var result = await _transactionVerificationService.VerifyAsync(paymentId);

        return Ok(result);
    }

    /// <summary>
    /// پرداخت و ثبت طرح اشتراکی
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Pay(Transaction transaction)
    {
        var twitchId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        transaction.TwitchId = new Guid(twitchId!);

        var result = await _transactionService.PayAsync(transaction);

        return Ok(result);
    }
}