using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class FollowerAwardConfiguration : AuditableConfiguration<FollowerAward>
{
    public override void Configure(EntityTypeBuilder<FollowerAward> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.TwitchAccountId)
            .IsRequired();
        builder.Property(x => x.Prize)
            .IsRequired();

        builder.HasOne(x => x.TwitchAccount)
            .WithMany(x => x.FollowerAwards)
            .HasForeignKey(x => x.TwitchAccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}