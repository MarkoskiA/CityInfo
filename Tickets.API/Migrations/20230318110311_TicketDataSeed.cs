using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.API.Migrations
{
    public partial class TicketDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Email", "Name", "PointOfInterestId" },
                values: new object[] { 1, "a@a.com", "Alex", 4 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Email", "Name", "PointOfInterestId" },
                values: new object[] { 2, "b@b.com", "Bob", 5 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Email", "Name", "PointOfInterestId" },
                values: new object[] { 3, "s@s.com", "Sarah", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
