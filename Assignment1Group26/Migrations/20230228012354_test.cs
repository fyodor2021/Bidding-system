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
                    ClienFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPassword = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
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
                    BidCost = table.Column<double>(type: "float", nullable: false),
                    BidStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetConditionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "ClientId", "ClienFirstName", "ClienLastName", "ClientPassword", "ClientUserName", "EmailConfirmed", "VerficationToken", "keepLoggedIn" },
                values: new object[,]
                {
                    { 1, "John", "Smith", "password", "john.smith@gmail.com", true, null, false },
                    { 2, "vedoor", "Barakat", "password", "Vendor.Barakat@gmail.com", true, null, false }
                });

            migrationBuilder.InsertData(
                table: "bids",
                columns: new[] { "BidId", "AssetConditionId", "BidCost", "BidDescription", "BidEndDate", "BidName", "BidStartDate", "CategoryId", "ClientId", "ImagePath" },
                values: new object[,]
                {
                    { 1, 1, 59.990000000000002, "High heel slingback shoes. Tied closure. Pointed toe.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3567), "LACE UP TIED HIGH HEELED SHOES", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3566), 1, 1, "~/Images/shoes.jpg" },
                    { 2, 2, 45.899999999999999, "Mini city bag. Handle and removable, adjustable crossbody strap. Magnetic closure.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3573), "MINI CITY BAG", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3572), 1, 1, "~/Images/pinkBag.jpg" },
                    { 3, 1, 69.989999999999995, "Mid-rise jeans with front pockets .", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3577), "WOMEN'S BELT LOOP CARGO TRF JEANS", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3576), 1, 1, "~/Images/jeans.jpg" },
                    { 4, 1, 39.990000000000002, "Openwork knit top with round neck and short sleeves.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3580), "RUFFLED KNIT TOP", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3579), 1, 1, "~/Images/knitShirt.jpg" },
                    { 5, 3, 29.989999999999998, "Long sleeves. Rib trim.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3584), "ZIP COLLAR SWEATSHIRT", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3583), 1, 1, "~/Images/menBlueHoddie.jpg" },
                    { 6, 1, 129.99000000000001, "Coat made of wool blend fabric.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3586), "WOOL BLEND COAT", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3586), 1, 1, "~/Images/coat.jpg" },
                    { 7, 2, 129.99000000000001, "Sneakers.Slightly chunky soles.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3589), "RUNNING SHOES", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3588), 1, 1, "~/Images/runningShoes.jpg" },
                    { 8, 3, 19.989999999999998, "Cotton sweater vest. Sleeveless. V-neckline. Rib trim.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3592), "TEXTURED KNIT VEST", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3591), 1, 1, "~/Images/vest.jpg" },
                    { 9, 1, 29.989999999999998, "Girl short sleeves dress with elastic cuffs.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3595), "ASSYMETRIC POPLIN DRESS", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3594), 1, 1, "~/Images/girlDress.jpg" },
                    { 10, 3, 649.99000000000001, "onsumer Notebook 15.6 FHD AMD Ryzen 5 5625U AMD Radeon Graphics 12GB 512GB SSD Windows 11 Home ", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3599), "LENOVO IdeaPad 3", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3598), 3, 1, "~/Images/lenovoIdeaPad3.jpg" },
                    { 11, 1, 1200.99, "16.1 QHD, Intel Core i7-11800H, NVIDIA GeForce RTX 3070, 16GB DDR4, 1TB SSD.", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3602), "HP OMEN 16-b0020ca Gaming Notebook", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3601), 3, 1, "~/Images/omen.jpg" },
                    { 12, 3, 899.99000000000001, "256GB Gold", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3604), "IPHONE 14 PRO MAX", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3604), 3, 1, "~/Images/iphone14.jpg" },
                    { 13, 1, 25250.0, "2018 MAZDA 3", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3610), "MAZDA 3", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3609), 2, 2, "~/Images/mazda32018.jpg" },
                    { 14, 1, 50150.0, "VW 310 Rampaging German Horse Power", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3614), "Golf R", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3613), 2, 1, "~/Images/golfR.jpg" },
                    { 15, 1, 70120.300000000003, "2023 chevy pick up Truck", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3617), "Chevy Silverado", new DateTime(2023, 2, 27, 20, 23, 54, 659, DateTimeKind.Local).AddTicks(3616), 2, 2, "~/Images/chevySilverado.jpg" }
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
                name: "assetConditions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
