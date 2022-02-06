using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Application.ViewModels.Transaction;

public class TransactionDto
{
    public Guid Id { get; set; }
    public Guid PlanId { get; set; }
    public string? PlanTitle { get; set; }
    public double PlanPrice { get; set; }
    public PlanType PlanType { get; set; }
    public PlanTime PlanTime { get; set; }
    public Guid TwitchId { get; set; }
    public string? Username { get; set; }
    public string? PaymentId { get; set; }
    public DateTime CreatedAt { get; set; }

}