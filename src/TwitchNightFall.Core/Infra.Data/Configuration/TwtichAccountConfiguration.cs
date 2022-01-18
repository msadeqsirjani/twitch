using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class TwtichAccountConfiguration : AuditableConfiguration<TwitchAccount>
{
    public override void Configure(EntityTypeBuilder<TwitchAccount> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasMany(x => x.FollowerAwards)
            .WithOne(x => x.TwitchAccount)
            .HasForeignKey(x => x.TwitchAccountId);

        builder.HasIndex(x => x.Username, "IX_TwitchAccount_Username")
            .IsUnique();
    }
}