﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwitchNightFall.Core.Infra.Data;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220304124021_UpdateDatabase-5")]
    partial class UpdateDatabase5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy")
                        .IsUnique()
                        .HasFilter("[CreatedBy] IS NOT NULL");

                    b.HasIndex(new[] { "Username" }, "IX_Administrator_Username")
                        .IsUnique();

                    b.ToTable("Administrator", "ray");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 728, DateTimeKind.Utc).AddTicks(9243),
                            Firstname = "admin",
                            IsActive = true,
                            Lastname = "admin",
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 728, DateTimeKind.Utc).AddTicks(9246),
                            Password = "0LfMrUOaFgd0CpvCf0oVBg==",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.ForgivenessAsync", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdministratorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ForgivenessType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlanId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Prize")
                        .HasColumnType("int");

                    b.Property<Guid>("TwitchId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("PlanId");

                    b.HasIndex("TwitchId");

                    b.ToTable("ForgivenessAsync", "ray");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DelayBetweenEveryPurchase")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlanTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Plan", "ray");

                    b.HasData(
                        new
                        {
                            Id = new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                            Count = 10,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8505),
                            DelayBetweenEveryPurchase = 5,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8506),
                            PlanTime = "Daily",
                            PlanType = "LuckRound",
                            Price = 0.99m,
                            Title = "10 rounds of luck one to five followers"
                        },
                        new
                        {
                            Id = new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                            Count = 140,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8516),
                            DelayBetweenEveryPurchase = 7,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8516),
                            PlanTime = "Weekly",
                            PlanType = "PurchaseFollower",
                            Price = 5.49m,
                            Title = "Subscription of 140 people per week"
                        },
                        new
                        {
                            Id = new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                            Count = 150,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8521),
                            DelayBetweenEveryPurchase = 30,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8521),
                            PlanTime = "Monthly",
                            PlanType = "PurchaseFollower",
                            Price = 4.99m,
                            Title = "Subscription of 150 people per month"
                        },
                        new
                        {
                            Id = new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                            Count = 175,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8529),
                            DelayBetweenEveryPurchase = 7,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8529),
                            PlanTime = "Weekly",
                            PlanType = "PurchaseFollower",
                            Price = 6.49m,
                            Title = "Subscription of 175 people per week"
                        },
                        new
                        {
                            Id = new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                            Count = 20,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8533),
                            DelayBetweenEveryPurchase = 5,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8534),
                            PlanTime = "Daily",
                            PlanType = "LuckRound",
                            Price = 1.89m,
                            Title = "20 rounds of luck one to five followers"
                        },
                        new
                        {
                            Id = new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                            Count = 300,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8542),
                            DelayBetweenEveryPurchase = 30,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8542),
                            PlanTime = "Monthly",
                            PlanType = "PurchaseFollower",
                            Price = 9.99m,
                            Title = "Subscription of 300 people per month"
                        },
                        new
                        {
                            Id = new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                            Count = 450,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8546),
                            DelayBetweenEveryPurchase = 30,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8547),
                            PlanTime = "Monthly",
                            PlanType = "PurchaseFollower",
                            Price = 14.49m,
                            Title = "Subscription of 450 people per month"
                        },
                        new
                        {
                            Id = new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                            Count = 50,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8551),
                            DelayBetweenEveryPurchase = 10,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8551),
                            PlanTime = "Daily",
                            PlanType = "LuckRound",
                            Price = 3.49m,
                            Title = "50 rounds of luck one to five followers"
                        },
                        new
                        {
                            Id = new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                            Count = 600,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8556),
                            DelayBetweenEveryPurchase = 30,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8557),
                            PlanTime = "Monthly",
                            PlanType = "PurchaseFollower",
                            Price = 18.99m,
                            Title = "Subscription of 600 people per month"
                        },
                        new
                        {
                            Id = new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                            Count = 70,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8575),
                            DelayBetweenEveryPurchase = 7,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8576),
                            PlanTime = "Weekly",
                            PlanType = "PurchaseFollower",
                            Price = 2.99m,
                            Title = "Subscription of 70 people per week"
                        },
                        new
                        {
                            Id = new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                            Count = 750,
                            CreatedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8580),
                            DelayBetweenEveryPurchase = 30,
                            ModifiedAt = new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8580),
                            PlanTime = "Monthly",
                            PlanType = "PurchaseFollower",
                            Price = 22.99m,
                            Title = "Subscription of 750 people per month"
                        });
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TwitchId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("TwitchId");

                    b.ToTable("Subscription", "ray");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<Guid>("TwitchId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("TwitchId");

                    b.ToTable("Transaction", "ray");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Twitch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Username" }, "IX_TwitchAccount_Username")
                        .IsUnique();

                    b.ToTable("Twitch", "ray");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Administrator", b =>
                {
                    b.HasOne("TwitchNightFall.Domain.Entities.Administrator", "Creator")
                        .WithOne()
                        .HasForeignKey("TwitchNightFall.Domain.Entities.Administrator", "CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.ForgivenessAsync", b =>
                {
                    b.HasOne("TwitchNightFall.Domain.Entities.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId");

                    b.HasOne("TwitchNightFall.Domain.Entities.Administrator", null)
                        .WithMany("ForgivenessAsync")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TwitchNightFall.Domain.Entities.Plan", "Plan")
                        .WithMany("ForgivenessAsync")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TwitchNightFall.Domain.Entities.Twitch", "Twitch")
                        .WithMany("ForgivenessAsync")
                        .HasForeignKey("TwitchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Plan");

                    b.Navigation("Twitch");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("TwitchNightFall.Domain.Entities.Plan", "Plan")
                        .WithMany("Subscription")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TwitchNightFall.Domain.Entities.Twitch", "Twitch")
                        .WithMany("Subscription")
                        .HasForeignKey("TwitchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("Twitch");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("TwitchNightFall.Domain.Entities.Plan", "Plan")
                        .WithMany("Transaction")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TwitchNightFall.Domain.Entities.Twitch", "Twitch")
                        .WithMany("Transaction")
                        .HasForeignKey("TwitchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("Twitch");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Administrator", b =>
                {
                    b.Navigation("ForgivenessAsync");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Plan", b =>
                {
                    b.Navigation("ForgivenessAsync");

                    b.Navigation("Subscription");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Twitch", b =>
                {
                    b.Navigation("ForgivenessAsync");

                    b.Navigation("Subscription");

                    b.Navigation("Transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
