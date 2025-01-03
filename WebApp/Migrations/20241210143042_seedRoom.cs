using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class seedRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNumber", "PolyclinicID", "Status" },
                values: new object[,]
                {
                    { 101, 1, "Available" },
                    { 102, 1, "Available" },
                    { 201, 2, "Available" },
                    { 202, 2, "Available" },
                    { 301, 3, "Available" },
                    { 302, 3, "Available" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: 302);
        }
    }
}
