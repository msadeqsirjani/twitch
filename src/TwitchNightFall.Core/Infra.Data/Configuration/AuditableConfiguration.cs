using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Domain.Common;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class AuditableConfiguration<T> : IEntityTypeConfiguration<T> where T : Auditable
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();
       
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.ModifiedAt)
            .IsRequired();
    }
}