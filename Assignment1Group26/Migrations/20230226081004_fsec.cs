using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class fsec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3390), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3389) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3398), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3397) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 3,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3401), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 4,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3404), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3403) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 5,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3407), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 6,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3410), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3409) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 7,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3414), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 8,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3417), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3416) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 9,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3420), new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 10,
                columns: new[] { "BidCost", "BidDescription", "BidEndDate", "BidName", "BidStartDate", "CategoryId", "ImagePath" },
                values: new object[] { 649.99000000000001, "onsumer Notebook 15.6 FHD AMD Ryzen 5 5625U AMD Radeon Graphics 12GB 512GB SSD Windows 11 Home ", new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3423), "LENOVO IdeaPad 3", new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3422), 3, "~/Images/lenovoIdeaPad3.jpg" });

            migrationBuilder.InsertData(
                table: "bids",
                columns: new[] { "BidId", "AssetConditionId", "BidCost", "BidDescription", "BidEndDate", "BidName", "BidStartDate", "CategoryId", "ClientId", "ImagePath" },
                values: new object[,]
                {
                    { 11, 1, 19.989999999999998, "16.1 QHD, Intel Core i7-11800H, NVIDIA GeForce RTX 3070, 16GB DDR4, 1TB SSD.", new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3426), "HP OMEN 16-b0020ca Gaming Notebook", new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3425), 3, 1, "~/Images/omen.jpg" },
                    { 12, 3, 899.99000000000001, "256GB Gold", new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3429), "IPHONE 14 PRO MAX", new DateTime(2023, 2, 26, 3, 10, 4, 670, DateTimeKind.Local).AddTicks(3428), 3, 1, "~/Images/iphone14.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 1,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3710), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3708) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 2,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3720), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3718) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 3,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3725), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3724) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 4,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3730), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3728) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 5,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3734), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3733) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 6,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3739), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 7,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3744), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 8,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3749), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3747) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 9,
                columns: new[] { "BidEndDate", "BidStartDate" },
                values: new object[] { new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3754), new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3752) });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 10,
                columns: new[] { "BidCost", "BidDescription", "BidEndDate", "BidName", "BidStartDate", "CategoryId", "ImagePath" },
                values: new object[] { 19.989999999999998, "Girl short sleeves dress with elastic cuffs.", new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3758), "ASSYMETRIC POPLIN DRESS", new DateTime(2023, 2, 26, 2, 53, 45, 527, DateTimeKind.Local).AddTicks(3757), 1, "~/Images/girlDress.jpg" });
        }
    }
}
