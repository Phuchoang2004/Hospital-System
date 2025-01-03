using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmentsDetail1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_Days_DayID",
                table: "DateDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_Hours_HourID",
                table: "DateDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_Polyclinics_PolyclinicID",
                table: "DateDetails");

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "DateDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DateDetails_RoomNumber",
                table: "DateDetails",
                column: "RoomNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_Days_DayID",
                table: "DateDetails",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "DayID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_Hours_HourID",
                table: "DateDetails",
                column: "HourID",
                principalTable: "Hours",
                principalColumn: "HourID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_Polyclinics_PolyclinicID",
                table: "DateDetails",
                column: "PolyclinicID",
                principalTable: "Polyclinics",
                principalColumn: "PolyclinicID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_Rooms_RoomNumber",
                table: "DateDetails",
                column: "RoomNumber",
                principalTable: "Rooms",
                principalColumn: "RoomNumber",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_Days_DayID",
                table: "DateDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_Hours_HourID",
                table: "DateDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_Polyclinics_PolyclinicID",
                table: "DateDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_Rooms_RoomNumber",
                table: "DateDetails");

            migrationBuilder.DropIndex(
                name: "IX_DateDetails_RoomNumber",
                table: "DateDetails");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "DateDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_Days_DayID",
                table: "DateDetails",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "DayID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_Hours_HourID",
                table: "DateDetails",
                column: "HourID",
                principalTable: "Hours",
                principalColumn: "HourID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_Polyclinics_PolyclinicID",
                table: "DateDetails",
                column: "PolyclinicID",
                principalTable: "Polyclinics",
                principalColumn: "PolyclinicID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
