using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class ForgivenessConfiguration : AuditableConfiguration<Forgiveness>
{
    public override void Configure(EntityTypeBuilder<Forgiveness> builder)
    {
        base.Configure(builder);

        builder.ToTable("Forgiveness", "ray");

        builder.Property(x => x.TwitchId)
            .IsRequired();
       
        builder.Property(x => x.Prize)
            .IsRequired();

        builder.HasOne(x => x.Twitch)
            .WithMany(x => x.Forgiveness)
            .HasForeignKey(x => x.TwitchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}