﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assetConditions",
                columns: table => new
                {
                    AssetConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetConditionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assetConditions", x => x.AssetConditionId);
                });

            migrationBuilder.CreateTable(
                name: "bidsPlaced",
                columns: table => new
                {
                    BidsPlacedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    BidAmount = table.Column<double>(type: "float", nullable: false),
                    WinOrLostEmailSent = table.Column<bool>(type: "bit", nullable: true),
                    BidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bidsPlaced", x => x.BidsPlacedId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientUserNameWithoutAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientPassword = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ClientRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    MultiPin = table.Column<int>(type: "int", nullable: false),
                    VerficationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    keepLoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    ClientPhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ClientBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    BidId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    TotalPaid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.PurchaseId);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedByStr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "bids",
                columns: table => new
                {
                    BidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidStartPrice = table.Column<double>(type: "float", nullable: false),
                    BidStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetConditionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    expired = table.Column<bool>(type: "bit", nullable: false),
                    HighestBid = table.Column<double>(type: "float", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bids", x => x.BidId);
                    table.ForeignKey(
                        name: "FK_bids_assetConditions_AssetConditionId",
                        column: x => x.AssetConditionId,
                        principalTable: "assetConditions",
                        principalColumn: "AssetConditionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bids_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bids_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "assetConditions",
                columns: new[] { "AssetConditionId", "AssetConditionStatus" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Lightly Used" },
                    { 3, "Used" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Clothes" },
                    { 2, "Cars" },
                    { 3, "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "ClientId", "Blocked", "ClientBirthDate", "ClientFirstName", "ClientImage", "ClientLastName", "ClientPassword", "ClientPhoneNumber", "ClientRole", "ClientUserName", "ClientUserNameWithoutAt", "EmailConfirmed", "MultiPin", "VerficationToken", "keepLoggedIn" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2023, 4, 14, 20, 26, 43, 261, DateTimeKind.Local).AddTicks(580), "John", null, "Smith", "password", "4379998049", "Client", "john.smith@gmail.com", null, true, 11111111, null, false },
                    { 2, false, new DateTime(2023, 4, 14, 20, 26, 43, 261, DateTimeKind.Local).AddTicks(614), "vedoor", null, "Barakat", "password", "4379998049", "Client", "Vedoor.Barakat@gmail.com", null, true, 11111111, null, false },
                    { 3, false, new DateTime(2023, 4, 14, 20, 26, 43, 261, DateTimeKind.Local).AddTicks(616), "Admin", null, "Admin", "123Password1$", "4379998049", "Admin", "Admin@gmail.com", null, true, 11111111, null, false }
                });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "ReviewId", "ClientId", "Comment", "CreatedBy", "CreatedByStr", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Awsome Experience, it was Delvired on Time, #HappyCustomer", 1, "john.smith@gmail.com", 1 },
                    { 2, 1, "terrible Experience, i'm Done! Buying from this seller, #SadSeller", 2, "Vedoor.Barakat@gmail.com", 2 },
                    { 3, 2, "Fair Experience, got what i Paid for, #FairCustomer", 1, "john.smith@gmail.com", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bids_AssetConditionId",
                table: "bids",
                column: "AssetConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_bids_CategoryId",
                table: "bids",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_bids_ClientId",
                table: "bids",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bids");

            migrationBuilder.DropTable(
                name: "bidsPlaced");

            migrationBuilder.DropTable(
                name: "purchases");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "assetConditions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
