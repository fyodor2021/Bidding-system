using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 1);

            migrationBuilder.AddColumn<double>(
                name: "BidAmount",
                table: "bidsPlaced",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 1,
                columns: new[] { "BidAmount", "BidDate" },
                values: new object[] { 17000.0, new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 2,
                columns: new[] { "BidAmount", "BidDate" },
                values: new object[] { 18000.0, new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(637) });

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 3,
                columns: new[] { "BidAmount", "BidDate" },
                values: new object[] { 19000.0, new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 4,
                columns: new[] { "BidAmount", "BidDate" },
                values: new object[] { 20000.0, new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(640) });

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 5,
                columns: new[] { "BidAmount", "BidDate" },
                values: new object[] { 21000.0, new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(641) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BidAmount",
                table: "bidsPlaced");

            migrationBuilder.InsertData(
                table: "bids",
                columns: new[] { "BidId", "AssetConditionId", "BidCost", "BidDescription", "BidEndDate", "BidName", "BidStartDate", "CategoryId", "ClientId", "ImageData", "Status" },
                values: new object[] { 1, 1, 59.990000000000002, "High heel slingback shoes. Tied closure. Pointed toe.", new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4528), "LACE UP TIED HIGH HEELED SHOES", new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4527), 1, 1, null, false });

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 1,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 2,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 3,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 4,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 5,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 10, 53, 290, DateTimeKind.Local).AddTicks(4515));
        }
    }
}
