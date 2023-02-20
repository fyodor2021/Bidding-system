using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetConditions",
                columns: table => new
                {
                    AssetConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetConditionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetConditions", x => x.AssetConditionId);
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
                    ClienFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfimed = table.Column<bool>(type: "bit", nullable: false),
                    VerficationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    keepLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "bids",
                columns: table => new
                {
                    BidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidCost = table.Column<int>(type: "int", nullable: false),
                    BidStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetConditionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bids", x => x.BidId);
                    table.ForeignKey(
                        name: "FK_bids_AssetConditions_AssetConditionId",
                        column: x => x.AssetConditionId,
                        principalTable: "AssetConditions",
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
                table: "AssetConditions",
                columns: new[] { "AssetConditionId", "AssetConditionName" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 3, "Lightly Used" },
                    { 4, "Used" }
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
                columns: new[] { "ClientId", "ClienFirstName", "ClienLastName", "ClientPassword", "ClientUserName", "EmailConfimed", "VerficationToken", "keepLoggedIn" },
                values: new object[,]
                {
                    { 1, "John", "Smith", "password", "john.smith@gmail.com", false, null, false },
                    { 2, "vedoor", "Barakat", "password", "Vendor.Barakat@gmail.com", false, null, false }
                });

            migrationBuilder.InsertData(
                table: "bids",
                columns: new[] { "BidId", "AssetConditionId", "BidCost", "BidDescription", "BidEndDate", "BidName", "BidStartDate", "CategoryId", "ClientId" },
                values: new object[,]
                {
                    { 1, 1, 20, "Long sleeve turtleneck sweater", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara CROP KNIT TURTLENECK SWEATER", new DateTime(2023, 2, 20, 12, 11, 19, 585, DateTimeKind.Local).AddTicks(1823), 1, 1 },
                    { 2, 1, 20, "Long sleeve turtleneck sweater", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara CROP KNIT TURTLENECK SWEATER", new DateTime(2023, 2, 20, 12, 11, 19, 585, DateTimeKind.Local).AddTicks(1828), 1, 1 },
                    { 3, 1, 20, "Long sleeve turtleneck sweater", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara CROP KNIT TURTLENECK SWEATER", new DateTime(2023, 2, 20, 12, 11, 19, 585, DateTimeKind.Local).AddTicks(1831), 1, 2 },
                    { 4, 1, 20, "Long sleeve turtleneck sweater", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara CROP KNIT TURTLENECK SWEATER", new DateTime(2023, 2, 20, 12, 11, 19, 585, DateTimeKind.Local).AddTicks(1834), 1, 1 },
                    { 5, 1, 20, "Long sleeve turtleneck sweater", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara CROP KNIT TURTLENECK SWEATER", new DateTime(2023, 2, 20, 12, 11, 19, 585, DateTimeKind.Local).AddTicks(1836), 1, 1 },
                    { 6, 1, 20, "Long sleeve turtleneck sweater", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara CROP KNIT TURTLENECK SWEATER", new DateTime(2023, 2, 20, 12, 11, 19, 585, DateTimeKind.Local).AddTicks(1839), 1, 1 },
                    { 7, 1, 20, "Long sleeve turtleneck sweater", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara CROP KNIT TURTLENECK SWEATER", new DateTime(2023, 2, 20, 12, 11, 19, 585, DateTimeKind.Local).AddTicks(1841), 1, 2 }
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
                name: "AssetConditions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
