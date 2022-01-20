using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Domain.Entities;

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

        builder.Property(x => x.CreatedBy);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.Creator)
            .WithOne()
            .HasForeignKey<Administrator>(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Forgiveness)
            .WithOne()
            .HasForeignKey(x => x.ModifiedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Username, "IX_Administrator_Username")
            .IsUnique();

        builder.HasData(new List<Administrator>
        {
            new()
            {
                Id = Guid.Parse("C0915809-B937-4E84-B7BA-97EFCF9AF77C"),
                Username = "admin",
                Password = Security.Encrypt("admin"),
                Firstname = "admin",
                Lastname = "admin",
                ProfileImageUrl = null,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                CreatedBy = null,
                IsActive = true
            }
        });
    }
}