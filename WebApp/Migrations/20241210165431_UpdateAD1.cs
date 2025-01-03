using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAD1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DateDetails",
                columns: new[] { "AppointmentDetailsID", "DateStatus", "DayID", "DoctorID", "HourID", "PatientID", "PolyclinicID", "RoomNumber" },
                values: new object[,]
                {
                    { 1, true, 1, null, 1, null, 1, 101 },
                    { 2, true, 1, null, 2, null, 1, 102 },
                    { 3, true, 2, null, 3, null, 2, 201 },
                    { 4, true, 2, null, 4, null, 2, 202 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DateDetails",
                keyColumn: "AppointmentDetailsID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DateDetails",
                keyColumn: "AppointmentDetailsID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DateDetails",
                keyColumn: "AppointmentDetailsID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DateDetails",
                keyColumn: "AppointmentDetailsID",
                keyValue: 4);
        }
    }
}
