using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Repository;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class AdministratorConfiguration : AuditableConfiguration<Administrator>
{
    public override void Configure(EntityTypeBuilder<Administrator> builder)
    {
        base.Configure(builder);

        builder.ToTable("Administrator", "ray");

        builder.Property(x => x.Firstname)
            .HasMaxLength(250);

        builder.Property(x => x.Lastname)
            .HasMaxLength(250);

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.Password)
            .IsRequired();

        builder.HasIndex(x => x.Username, "IX_Administrator_Username")
            .IsUnique();
    }
}