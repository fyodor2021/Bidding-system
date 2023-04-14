using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 20, 53, 226, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 20, 53, 226, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 3,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 20, 53, 226, DateTimeKind.Local).AddTicks(5668));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "purchases");

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
    }
}
