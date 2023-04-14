﻿// <auto-generated />
using System;
using Assignment1Group26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1Group26.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
<<<<<<<< HEAD:Assignment1Group26/Migrations/20230414201200_second.Designer.cs
    [Migration("20230414201200_second")]
    partial class second
========
    [Migration("20230414201534_int")]
    partial class @int
>>>>>>>> 7683f63ca8a3f02fb34321767fdb8bcf666e5dfa:Assignment1Group26/Migrations/20230414201534_int.Designer.cs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("AssetConditionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetConditionId");

                    b.ToTable("assetConditions");

                    b.HasData(
                        new
                        {
                            AssetConditionId = 1,
                            AssetConditionStatus = "New"
                        },
                        new
                        {
                            AssetConditionId = 2,
                            AssetConditionStatus = "Lightly Used"
                        },
                        new
                        {
                            AssetConditionId = 3,
                            AssetConditionStatus = "Used"
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

                    b.Property<double?>("BidStartPrice")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<double?>("HighestBid")
                        .HasColumnType("float");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("expired")
                        .HasColumnType("bit");

                    b.HasKey("BidId");

                    b.HasIndex("AssetConditionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.ToTable("bids");
                });

            modelBuilder.Entity("Assignment1Group26.Models.BidsPlaced", b =>
                {
                    b.Property<int>("BidsPlacedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidsPlacedId"), 1L, 1);

                    b.Property<double>("BidAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("BidDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BidId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<bool?>("WinOrLostEmailSent")
                        .HasColumnType("bit");

                    b.HasKey("BidsPlacedId");

                    b.ToTable("bidsPlaced");
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

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ClientBirthDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ClientFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ClientImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ClientLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientPassword")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ClientPhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ClientRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientUserNameWithoutAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("MultiPin")
                        .HasColumnType("int");

                    b.Property<string>("VerficationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("keepLoggedIn")
                        .HasColumnType("bit");

                    b.HasKey("ClientId");

                    b.ToTable("clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Blocked = false,
<<<<<<<< HEAD:Assignment1Group26/Migrations/20230414201200_second.Designer.cs
                            ClientBirthDate = new DateTime(2023, 4, 14, 16, 11, 59, 772, DateTimeKind.Local).AddTicks(1309),
========
                            ClientBirthDate = new DateTime(2023, 4, 14, 16, 15, 34, 439, DateTimeKind.Local).AddTicks(2767),
>>>>>>>> 7683f63ca8a3f02fb34321767fdb8bcf666e5dfa:Assignment1Group26/Migrations/20230414201534_int.Designer.cs
                            ClientFirstName = "John",
                            ClientLastName = "Smith",
                            ClientPassword = "password",
                            ClientPhoneNumber = "4379998049",
                            ClientRole = "Client",
                            ClientUserName = "john.smith@gmail.com",
                            EmailConfirmed = true,
                            MultiPin = 11111111,
                            keepLoggedIn = false
                        },
                        new
                        {
                            ClientId = 2,
                            Blocked = false,
<<<<<<<< HEAD:Assignment1Group26/Migrations/20230414201200_second.Designer.cs
                            ClientBirthDate = new DateTime(2023, 4, 14, 16, 11, 59, 772, DateTimeKind.Local).AddTicks(1366),
========
                            ClientBirthDate = new DateTime(2023, 4, 14, 16, 15, 34, 439, DateTimeKind.Local).AddTicks(2799),
>>>>>>>> 7683f63ca8a3f02fb34321767fdb8bcf666e5dfa:Assignment1Group26/Migrations/20230414201534_int.Designer.cs
                            ClientFirstName = "vedoor",
                            ClientLastName = "Barakat",
                            ClientPassword = "password",
                            ClientPhoneNumber = "4379998049",
                            ClientRole = "Client",
                            ClientUserName = "Vedoor.Barakat@gmail.com",
                            EmailConfirmed = true,
                            MultiPin = 11111111,
                            keepLoggedIn = false
                        },
                        new
                        {
                            ClientId = 3,
                            Blocked = false,
<<<<<<<< HEAD:Assignment1Group26/Migrations/20230414201200_second.Designer.cs
                            ClientBirthDate = new DateTime(2023, 4, 14, 16, 11, 59, 772, DateTimeKind.Local).AddTicks(1371),
========
                            ClientBirthDate = new DateTime(2023, 4, 14, 16, 15, 34, 439, DateTimeKind.Local).AddTicks(2802),
>>>>>>>> 7683f63ca8a3f02fb34321767fdb8bcf666e5dfa:Assignment1Group26/Migrations/20230414201534_int.Designer.cs
                            ClientFirstName = "josephine",
                            ClientLastName = "abdulaziz",
                            ClientPassword = "juju123",
                            ClientPhoneNumber = "4379998049",
                            ClientRole = "Admin",
                            ClientUserName = "juju.josedore@gmail.com",
                            EmailConfirmed = true,
                            MultiPin = 11111111,
                            keepLoggedIn = false
                        });
<<<<<<<< HEAD:Assignment1Group26/Migrations/20230414201200_second.Designer.cs
                });

            modelBuilder.Entity("Assignment1Group26.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseId"), 1L, 1);

                    b.Property<int>("BidId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPaid")
                        .HasColumnType("float");

                    b.HasKey("PurchaseId");

                    b.ToTable("purchases");
========
>>>>>>>> 7683f63ca8a3f02fb34321767fdb8bcf666e5dfa:Assignment1Group26/Migrations/20230414201534_int.Designer.cs
                });

            modelBuilder.Entity("Assignment1Group26.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("CreatedByStr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.ToTable("reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            ClientId = 1,
                            Comment = "Awsome Experience, it was Delvired on Time, #HappyCustomer",
                            CreatedBy = 1,
                            CreatedByStr = "john.smith@gmail.com",
                            Rating = 1
                        },
                        new
                        {
                            ReviewId = 2,
                            ClientId = 1,
                            Comment = "terrible Experience, i'm Done! Buying from this seller, #SadSeller",
                            CreatedBy = 2,
                            CreatedByStr = "Vedoor.Barakat@gmail.com",
                            Rating = 2
                        },
                        new
                        {
                            ReviewId = 3,
                            ClientId = 2,
                            Comment = "Fair Experience, got what i Paid for, #FairCustomer",
                            CreatedBy = 1,
                            CreatedByStr = "john.smith@gmail.com",
                            Rating = 2
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
