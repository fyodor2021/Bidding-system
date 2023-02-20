﻿// <auto-generated />
using System;
using Assignment1Group26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1Group26.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment1Group26.Models.AssetCondition", b =>
                {
                    b.Property<int>("AssetConditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetConditionId"), 1L, 1);

                    b.Property<string>("AssetConditionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetConditionId");

                    b.ToTable("AssetConditions");

                    b.HasData(
                        new
                        {
                            AssetConditionId = 1,
                            AssetConditionName = "New"
                        },
                        new
                        {
                            AssetConditionId = 3,
                            AssetConditionName = "Lightly Used"
                        },
                        new
                        {
                            AssetConditionId = 4,
                            AssetConditionName = "Used"
                        });
                });

            modelBuilder.Entity("Assignment1Group26.Models.Bid", b =>
                {
                    b.Property<int>("BidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidId"), 1L, 1);

                    b.Property<int>("AssetConditionId")
                        .HasColumnType("int");

                    b.Property<int?>("BidCost")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("BidDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BidEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BidName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BidStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("BidId");

                    b.HasIndex("AssetConditionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.ToTable("bids");

                    b.HasData(
                        new
                        {
                            BidId = 1,
                            AssetConditionId = 1,
                            BidCost = 20,
                            BidDescription = "Long sleeve turtleneck sweater",
                            BidEndDate = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                            BidStartDate = new DateTime(2023, 2, 20, 8, 57, 53, 699, DateTimeKind.Local).AddTicks(491),
                            CategoryId = 1,
                            ClientId = 1
                        },
                        new
                        {
                            BidId = 2,
                            AssetConditionId = 1,
                            BidCost = 20,
                            BidDescription = "Long sleeve turtleneck sweater",
                            BidEndDate = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                            BidStartDate = new DateTime(2023, 2, 20, 8, 57, 53, 699, DateTimeKind.Local).AddTicks(498),
                            CategoryId = 1,
                            ClientId = 1
                        },
                        new
                        {
                            BidId = 3,
                            AssetConditionId = 1,
                            BidCost = 20,
                            BidDescription = "Long sleeve turtleneck sweater",
                            BidEndDate = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                            BidStartDate = new DateTime(2023, 2, 20, 8, 57, 53, 699, DateTimeKind.Local).AddTicks(501),
                            CategoryId = 1,
                            ClientId = 2
                        },
                        new
                        {
                            BidId = 4,
                            AssetConditionId = 1,
                            BidCost = 20,
                            BidDescription = "Long sleeve turtleneck sweater",
                            BidEndDate = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                            BidStartDate = new DateTime(2023, 2, 20, 8, 57, 53, 699, DateTimeKind.Local).AddTicks(503),
                            CategoryId = 1,
                            ClientId = 1
                        },
                        new
                        {
                            BidId = 5,
                            AssetConditionId = 1,
                            BidCost = 20,
                            BidDescription = "Long sleeve turtleneck sweater",
                            BidEndDate = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                            BidStartDate = new DateTime(2023, 2, 20, 8, 57, 53, 699, DateTimeKind.Local).AddTicks(506),
                            CategoryId = 1,
                            ClientId = 1
                        },
                        new
                        {
                            BidId = 6,
                            AssetConditionId = 1,
                            BidCost = 20,
                            BidDescription = "Long sleeve turtleneck sweater",
                            BidEndDate = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                            BidStartDate = new DateTime(2023, 2, 20, 8, 57, 53, 699, DateTimeKind.Local).AddTicks(509),
                            CategoryId = 1,
                            ClientId = 1
                        },
                        new
                        {
                            BidId = 7,
                            AssetConditionId = 1,
                            BidCost = 20,
                            BidDescription = "Long sleeve turtleneck sweater",
                            BidEndDate = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                            BidStartDate = new DateTime(2023, 2, 20, 8, 57, 53, 699, DateTimeKind.Local).AddTicks(512),
                            CategoryId = 1,
                            ClientId = 2
                        });
                });

            modelBuilder.Entity("Assignment1Group26.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Clothes"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Cars"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Electronics"
                        });
                });

            modelBuilder.Entity("Assignment1Group26.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("ClienFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClienLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfimed")
                        .HasColumnType("bit");

                    b.Property<bool>("keepLoggedIn")
                        .HasColumnType("bit");

                    b.HasKey("ClientId");

                    b.ToTable("clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            ClienFirstName = "John",
                            ClienLastName = "Smith",
                            ClientPassword = "password",
                            ClientUserName = "john.smith@gmail.com",
                            EmailConfimed = false,
                            keepLoggedIn = false
                        },
                        new
                        {
                            ClientId = 2,
                            ClienFirstName = "vedoor",
                            ClienLastName = "Barakat",
                            ClientPassword = "password",
                            ClientUserName = "Vendor.Barakat@gmail.com",
                            EmailConfimed = false,
                            keepLoggedIn = false
                        });
                });

            modelBuilder.Entity("Assignment1Group26.Models.Bid", b =>
                {
                    b.HasOne("Assignment1Group26.Models.AssetCondition", "AssetCondition")
                        .WithMany()
                        .HasForeignKey("AssetConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1Group26.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1Group26.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetCondition");

                    b.Navigation("Category");

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
