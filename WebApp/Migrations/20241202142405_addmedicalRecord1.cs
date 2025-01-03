using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class addmedicalRecord1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "ID", "Detail", "UserID" },
                values: new object[,]
                {
                    { 1, "Has high blood pressure", 1 },
                    { 2, "Thang nay bi benh dep trai giai doan cuoi, dep trai ko the chua dc, noi chung la vay!", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalRecords",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedicalRecords",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
