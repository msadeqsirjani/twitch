﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwitchNightFall.Core.Infra.Data;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
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
                            CreatedAt = new DateTime(2022, 1, 27, 11, 5, 29, 407, DateTimeKind.Utc).AddTicks(7398),
                            Firstname = "admin",
                            IsActive = true,
                            Lastname = "admin",
                            ModifiedAt = new DateTime(2022, 1, 27, 11, 5, 29, 407, DateTimeKind.Utc).AddTicks(7401),
                            Password = "0LfMrUOaFgd0CpvCf0oVBg==",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Forgiveness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdministratorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Prize")
                        .HasColumnType("int");

                    b.Property<Guid>("TwitchId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("TwitchId");

                    b.ToTable("Forgiveness", "ray");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.ResetPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SingleUseCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ResetPassword", "ray");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Twitch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Forgiveness", b =>
                {
                    b.HasOne("TwitchNightFall.Domain.Entities.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId");

                    b.HasOne("TwitchNightFall.Domain.Entities.Administrator", null)
                        .WithMany("Forgiveness")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TwitchNightFall.Domain.Entities.Twitch", "Twitch")
                        .WithMany("Forgiveness")
                        .HasForeignKey("TwitchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Twitch");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Administrator", b =>
                {
                    b.Navigation("Forgiveness");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.Twitch", b =>
                {
                    b.Navigation("Forgiveness");
                });
#pragma warning restore 612, 618
        }
    }
}
