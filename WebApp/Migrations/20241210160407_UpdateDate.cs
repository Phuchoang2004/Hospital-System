using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserID",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserID",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorID",
                table: "Appointments",
                column: "DoctorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientID",
                table: "Appointments",
                column: "PatientID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointments",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                newName: "IX_Appointments_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserID",
                table: "Appointments",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
