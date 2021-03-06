using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class TwitchConfiguration : AuditableConfiguration<Twitch>
{
    public override void Configure(EntityTypeBuilder<Twitch> builder)
    {
        base.Configure(builder);

        builder.ToTable("Twitch", "ray");

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasMany(x => x.Forgiveness)
            .WithOne(x => x.Twitch)
            .HasForeignKey(x => x.TwitchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Subscription)
            .WithOne(x => x.Twitch)
            .HasForeignKey(x => x.TwitchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Transaction)
            .WithOne(x => x.Twitch)
            .HasForeignKey(x => x.TwitchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.Username, "IX_TwitchAccount_Username")
            .IsUnique();
    }
}