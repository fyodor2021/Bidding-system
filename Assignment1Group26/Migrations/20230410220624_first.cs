﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class first : Migration
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
                    ClientPassword = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ClientRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    blocked = table.Column<bool>(type: "bit", nullable: false),
                    VerficationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    keepLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
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
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    BidCost = table.Column<double>(type: "float", nullable: false),
                    BidStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetConditionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
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
                table: "reviews",
                columns: new[] { "ReviewId", "ClientId", "Comment", "CreatedBy", "CreatedByStr" },
                values: new object[,]
                {
                    { 1, 1, "Awsome Experience, it was Delvired on Time, #HappyCustomer", 1, "john.smith@gmail.com" },
                    { 2, 1, "terrible Experience, i'm Done! Buying from this seller, #SadSeller", 2, "Vedoor.Barakat@gmail.com" },
                    { 3, 2, "Fair Experience, got what i Paid for, #FairCustomer", 1, "john.smith@gmail.com" }
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
