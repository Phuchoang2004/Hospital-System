using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class MoreRoomForAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DateDetails",
                columns: new[] { "AppointmentDetailsID", "DateStatus", "DayID", "DoctorID", "HourID", "PatientID", "PolyclinicID", "RoomNumber" },
                values: new object[,]
                {
                    { 5, true, 3, null, 3, null, 3, 301 },
                    { 6, true, 3, null, 4, null, 2, 302 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DateDetails",
                keyColumn: "AppointmentDetailsID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DateDetails",
                keyColumn: "AppointmentDetailsID",
                keyValue: 6);
        }
    }
}
