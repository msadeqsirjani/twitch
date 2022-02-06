using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class TransactionConfiguration : AuditableConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder.ToTable("Transaction", "ray");

        builder.Property(x => x.PlanId);
        builder.Property(x => x.TwitchId);
        builder.Property(x => x.PaymentId);
        builder.Property(x => x.Price)
            .HasColumnType("money");

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.Transaction)
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Twitch)
            .WithMany(x => x.Transaction)
            .HasForeignKey(x => x.TwitchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}