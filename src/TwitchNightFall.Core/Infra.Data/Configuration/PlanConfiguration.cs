using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitchNightFall.Domain.Entities;
using TwitchNightFall.Domain.Enums;

namespace TwitchNightFall.Core.Infra.Data.Configuration;

public class PlanConfiguration : AuditableConfiguration<Plan>
{
    public override void Configure(EntityTypeBuilder<Plan> builder)
    {
        base.Configure(builder);

        builder.ToTable("Plan", "ray");

        builder.Property(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(150);

        builder.Property(x => x.Price)
            .HasColumnType("money");

        builder.Property(x => x.Count);

        builder.Property(x => x.PlanType)
            .HasConversion<string>();

        builder.Property(x => x.PlanTime)
            .HasConversion<string>();

        builder.Property(x => x.DelayBetweenEveryPurchase);

        builder.HasMany(x => x.Subscription)
            .WithOne(x => x.Plan)
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Transaction)
            .WithOne(x => x.Plan)
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Forgiveness)
            .WithOne(x => x.Plan)
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<Plan>
        {
            new()
            {
                Id = new Guid("42A62722-2C58-4F59-A81F-487141A288BB"),
                Title = "10 rounds of luck one to five followers",
                Price = 0.99,
                Count = 10,
                PlanType = PlanType.LuckRound,
                PlanTime = PlanTime.Daily,
                DelayBetweenEveryPurchase = 5,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("4B01F654-1410-492C-8B97-BBB9E142B372"),
                Title = "Subscription of 140 people per week",
                Price = 5.49,
                Count = 140,
                PlanType = PlanType.PurchaseFollower,
                PlanTime = PlanTime.Weekly,
                DelayBetweenEveryPurchase = 7,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("8E5E29EB-2017-4D75-9CF6-7C8B8BF5B9B5"),
                Title = "Subscription of 150 people per month",
                Price = 4.99,
                Count = 150,
                PlanType = PlanType.PurchaseFollower,
                PlanTime = PlanTime.Monthly,
                DelayBetweenEveryPurchase = 30,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("D2FC0919-E8E6-4AD5-9561-456725280B59"),
                Title = "Subscription of 175 people per week",
                Price = 6.49,
                Count = 175,
                PlanType = PlanType.PurchaseFollower,
                PlanTime = PlanTime.Weekly,
                DelayBetweenEveryPurchase = 7,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("B55BCAAB-901E-4D30-8E82-E5572B84937C"),
                Title = "20 rounds of luck one to five followers",
                Price = 1.89,
                Count = 20,
                PlanType = PlanType.LuckRound,
                PlanTime = PlanTime.Daily,
                DelayBetweenEveryPurchase = 5,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("69B933C5-58D1-41D3-8ABC-18DC0C5A40F4"),
                Title = "Subscription of 300 people per month",
                Price = 9.99,
                Count = 300,
                PlanType = PlanType.PurchaseFollower,
                PlanTime = PlanTime.Monthly,
                DelayBetweenEveryPurchase = 30,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("06E71005-69D6-4AD4-B218-7BD47DBEED04"),
                Title = "Subscription of 450 people per month",
                Price = 14.49,
                Count = 450,
                PlanType = PlanType.PurchaseFollower,
                PlanTime = PlanTime.Monthly,
                DelayBetweenEveryPurchase = 30,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("95DF2344-8FB7-4F20-BB51-F1BF1F5618C0"),
                Title = "50 rounds of luck one to five followers",
                Price = 3.49,
                Count = 50,
                PlanType = PlanType.LuckRound,
                PlanTime = PlanTime.Daily,
                DelayBetweenEveryPurchase = 10,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            }, 
            new()
            {
                Id = new Guid("F75A9840-2C97-4F1C-91A0-FD6C68D49F4A"),
                Title = "Subscription of 600 people per month",
                Price = 18.99,
                Count = 600,
                PlanType = PlanType.PurchaseFollower,
                PlanTime = PlanTime.Monthly,
                DelayBetweenEveryPurchase = 30,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("8D96397F-A217-43A7-8F9B-91CFF10FD135"),
                Title = "Subscription of 70 people per week",
                Price = 2.99,
                Count = 70,
                PlanType = PlanType.PurchaseFollower,
                PlanTime = PlanTime.Weekly,
                DelayBetweenEveryPurchase = 7,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("5F31BB44-BA41-4CBA-97E5-E0152BAEB259"),
                Title = "Subscription of 750 people per month",
                Price = 22.99,
                Count = 750,
                PlanType = PlanType.PurchaseFollower,
                PlanTime = PlanTime.Monthly,
                DelayBetweenEveryPurchase = 30,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            }
        });
    }
}