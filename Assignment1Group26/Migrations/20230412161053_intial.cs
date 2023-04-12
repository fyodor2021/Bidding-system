using System;
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
                    ClientPassword = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ClientRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    MultiPin = table.Column<int>(type: "int", nullable: false),
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
                    Status = table.Column<bool>(type: "bit", nullable: false),
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
                table: "bidsPlaced",
                columns: new[] { "BidsPlacedId", "BidDate", "BidId", "ClientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4485), 1, 1 },
                    { 2, new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4511), 1, 1 },
                    { 3, new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4513), 1, 1 },
                    { 4, new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4514), 1, 2 },
                    { 5, new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4515), 1, 2 }
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
                columns: new[] { "ClientId", "Blocked", "ClientFirstName", "ClientLastName", "ClientPassword", "ClientRole", "ClientUserName", "EmailConfirmed", "MultiPin", "VerficationToken", "keepLoggedIn" },
                values: new object[,]
                {
                    { 1, false, "John", "Smith", "password", "Client", "john.smith@gmail.com", true, 11111111, null, false },
                    { 2, false, "vedoor", "Barakat", "password", "Client", "Vedoor.Barakat@gmail.com", true, 11111111, null, false },
                    { 3, false, "josephine", "abdulaziz", "juju123", "Admin", "juju.josedore@gmail.com", true, 11111111, null, false }
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

            migrationBuilder.InsertData(
                table: "bids",
                columns: new[] { "BidId", "AssetConditionId", "BidCost", "BidDescription", "BidEndDate", "BidName", "BidStartDate", "CategoryId", "ClientId", "ImageData", "Status" },
                values: new object[] { 1, 1, 59.990000000000002, "High heel slingback shoes. Tied closure. Pointed toe.", new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4528), "LACE UP TIED HIGH HEELED SHOES", new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4527), 1, 1, null, false });

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
