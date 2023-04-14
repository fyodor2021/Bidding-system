using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    BidId = table.Column<int>(type: "int", nullable: false),
                    TotalPaid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.PurchaseId);
                });

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 11, 59, 772, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 11, 59, 772, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 3,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 11, 59, 772, DateTimeKind.Local).AddTicks(1371));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchases");

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 14, 31, 53, 615, DateTimeKind.Local).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 14, 31, 53, 615, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 3,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 14, 31, 53, 615, DateTimeKind.Local).AddTicks(6256));
        }
    }
}
