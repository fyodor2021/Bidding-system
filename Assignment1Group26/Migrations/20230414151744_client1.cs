using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class client1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "ClientId", "Blocked", "ClientBirthDate", "ClientFirstName", "ClientImage", "ClientLastName", "ClientPassword", "ClientPhoneNumber", "ClientRole", "ClientUserName", "EmailConfirmed", "MultiPin", "VerficationToken", "keepLoggedIn" },
                values: new object[] { 1, false, new DateTime(2023, 4, 14, 11, 17, 44, 589, DateTimeKind.Local).AddTicks(3436), "John", null, "Smith", "password", "4379998049", "Client", "john.smith@gmail.com", true, 11111111, null, false });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "ClientId", "Blocked", "ClientBirthDate", "ClientFirstName", "ClientImage", "ClientLastName", "ClientPassword", "ClientPhoneNumber", "ClientRole", "ClientUserName", "EmailConfirmed", "MultiPin", "VerficationToken", "keepLoggedIn" },
                values: new object[] { 2, false, new DateTime(2023, 4, 14, 11, 17, 44, 589, DateTimeKind.Local).AddTicks(3514), "vedoor", null, "Barakat", "password", "4379998049", "Client", "Vedoor.Barakat@gmail.com", true, 11111111, null, false });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "ClientId", "Blocked", "ClientBirthDate", "ClientFirstName", "ClientImage", "ClientLastName", "ClientPassword", "ClientPhoneNumber", "ClientRole", "ClientUserName", "EmailConfirmed", "MultiPin", "VerficationToken", "keepLoggedIn" },
                values: new object[] { 3, false, new DateTime(2023, 4, 14, 11, 17, 44, 589, DateTimeKind.Local).AddTicks(3518), "josephine", null, "abdulaziz", "juju123", "4379998049", "Admin", "juju.josedore@gmail.com", true, 11111111, null, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
