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

    public DbSet<Twitch> Twitch { get; set; }
    public DbSet<Forgiveness> Forgiveness { get; set; }
    public DbSet<Administrator> Administrator { get; set; }
    public DbSet<ResetPassword> ResetPassword { get; set; }
    public DbSet<Subscription> Subscription { get; set; }
    public DbSet<Plan> Plan { get; set; }
    public DbSet<Transaction> Transaction { get; set; }

    public override int SaveChanges()
    {
        ApplyAuditing();

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TwtichConfiguration());
        modelBuilder.ApplyConfiguration(new ForgivenessConfiguration());
        modelBuilder.ApplyConfiguration(new AdministratorConfiguration());
        modelBuilder.ApplyConfiguration(new ResetPasswordConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
        modelBuilder.ApplyConfiguration(new PlanConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
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