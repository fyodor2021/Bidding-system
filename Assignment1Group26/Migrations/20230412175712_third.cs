using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BidCost",
                table: "bids",
                newName: "BidStartPrice");

            migrationBuilder.AddColumn<double>(
                name: "HighestBid",
                table: "bids",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 1,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 2,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2383));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 3,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 4,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 5,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2388));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBid",
                table: "bids");

            migrationBuilder.RenameColumn(
                name: "BidStartPrice",
                table: "bids",
                newName: "BidCost");

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 1,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 2,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 3,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 4,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(640));

            migrationBuilder.UpdateData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 5,
                column: "BidDate",
                value: new DateTime(2023, 4, 12, 12, 16, 31, 599, DateTimeKind.Local).AddTicks(641));
        }
    }
}
