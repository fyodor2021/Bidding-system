using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class @int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientUserNameWithoutAt",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 15, 34, 439, DateTimeKind.Local).AddTicks(2767));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 15, 34, 439, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 3,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 16, 15, 34, 439, DateTimeKind.Local).AddTicks(2802));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientUserNameWithoutAt",
                table: "clients");

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 15, 21, 57, 937, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 15, 21, 57, 937, DateTimeKind.Local).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 3,
                column: "ClientBirthDate",
                value: new DateTime(2023, 4, 14, 15, 21, 57, 937, DateTimeKind.Local).AddTicks(3459));
        }
    }
}
