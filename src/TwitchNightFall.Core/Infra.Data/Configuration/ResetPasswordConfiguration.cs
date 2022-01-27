using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class ResetPasswordConfiguration : AuditableConfiguration<ResetPassword>
{
    public override void Configure(EntityTypeBuilder<ResetPassword> builder)
    {
        base.Configure(builder);

        builder.ToTable("ResetPassword", "ray");

        builder.Property(x => x.Id);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
        builder.Property(x => x.SingleUseCode).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Expiry).IsRequired();
    }
}