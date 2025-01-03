using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmentsDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "DateDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "DateDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DateDetails_DoctorID",
                table: "DateDetails",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DateDetails_PatientID",
                table: "DateDetails",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_AspNetUsers_DoctorID",
                table: "DateDetails",
                column: "DoctorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateDetails_AspNetUsers_PatientID",
                table: "DateDetails",
                column: "PatientID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_AspNetUsers_DoctorID",
                table: "DateDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DateDetails_AspNetUsers_PatientID",
                table: "DateDetails");

            migrationBuilder.DropIndex(
                name: "IX_DateDetails_DoctorID",
                table: "DateDetails");

            migrationBuilder.DropIndex(
                name: "IX_DateDetails_PatientID",
                table: "DateDetails");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "DateDetails");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "DateDetails");
        }
    }
}
