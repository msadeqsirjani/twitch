using Microsoft.EntityFrameworkCore;
using TwitchNightFall.Core.Infra.Data.Configuration;
using TwitchNightFall.Domain.Common;
using TwitchNightFall.Domain.Entities;

namespace TwitchNightFall.Core.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<TwitchAccount> TwitchAccounts { get; set; }
    public DbSet<FollowerAward> FollowerAwards { get; set; }

    public override int SaveChanges()
    {
        ApplyAuditing();

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TwtichAccountConfiguration());
        modelBuilder.ApplyConfiguration(new FollowerAwardConfiguration());
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ApplyAuditing();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ApplyAuditing();

        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new())
    {
        ApplyAuditing();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void ApplyAuditing()
    {
        ChangeTracker.DetectChanges();

        var records = ChangeTracker.Entries();
        var entityEntries = records.ToList();
        
        var addedEntries = entityEntries.Where(x => x.State == EntityState.Added)
            .Select(x => x.Entity)
            .OfType<Auditable>()
            .ToList();
        
        var updatedEntries = entityEntries.Where(x => x.State == EntityState.Modified)
            .Select(x => x.Entity)
            .OfType<Auditable>()
            .ToList();

        var now = DateTime.UtcNow;

        addedEntries.ForEach(x =>
        {
            x.CreatedAt = now;
            x.ModifiedAt = now;
        });

        updatedEntries.ForEach(x =>
        {
            x.ModifiedAt = now;
        });
    }
}