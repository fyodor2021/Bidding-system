using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class forth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "bidsPlaced",
                keyColumn: "BidsPlacedId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClientBirthDate",
                table: "clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "ClientImage",
                table: "clients",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientPhoneNumber",
                table: "clients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientBirthDate",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "ClientImage",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "ClientPhoneNumber",
                table: "clients");

            migrationBuilder.InsertData(
                table: "bidsPlaced",
                columns: new[] { "BidsPlacedId", "BidAmount", "BidDate", "BidId", "ClientId" },
                values: new object[,]
                {
                    { 1, 17000.0, new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2327), 1, 1 },
                    { 2, 18000.0, new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2383), 1, 1 },
                    { 3, 19000.0, new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2385), 1, 1 },
                    { 4, 20000.0, new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2387), 1, 2 },
                    { 5, 21000.0, new DateTime(2023, 4, 12, 13, 57, 12, 309, DateTimeKind.Local).AddTicks(2388), 1, 2 }
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
        }
    }
}
