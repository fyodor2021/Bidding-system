using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1Group26.Migrations
{
    public partial class Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "ClienFirstName", "ClienLastName", "ClientPassword", "ClientUserName" },
                values: new object[] { 1, "John", "Smith", "password", "john.smith@gmail.com" });

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 1,
                column: "BidStartDate",
                value: new DateTime(2023, 2, 18, 13, 18, 29, 809, DateTimeKind.Local).AddTicks(9645));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.UpdateData(
                table: "bids",
                keyColumn: "BidId",
                keyValue: 1,
                column: "BidStartDate",
                value: new DateTime(2023, 2, 18, 13, 15, 23, 473, DateTimeKind.Local).AddTicks(3982));
        }
    }
}
