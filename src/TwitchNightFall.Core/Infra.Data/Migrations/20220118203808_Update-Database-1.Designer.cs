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
    [Migration("20220118203808_Update-Database-1")]
    partial class UpdateDatabase1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.FollowerAward", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Prize")
                        .HasColumnType("int");

                    b.Property<Guid>("TwitchAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TwitchAccountId");

                    b.ToTable("FollowerAwards");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.TwitchAccount", b =>
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

                    b.ToTable("TwitchAccounts");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.FollowerAward", b =>
                {
                    b.HasOne("TwitchNightFall.Domain.Entities.TwitchAccount", "TwitchAccount")
                        .WithMany("FollowerAwards")
                        .HasForeignKey("TwitchAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TwitchAccount");
                });

            modelBuilder.Entity("TwitchNightFall.Domain.Entities.TwitchAccount", b =>
                {
                    b.Navigation("FollowerAwards");
                });
#pragma warning restore 612, 618
        }
    }
}
