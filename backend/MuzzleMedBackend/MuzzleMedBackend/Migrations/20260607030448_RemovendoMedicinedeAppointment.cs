using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuzzleMedBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoMedicinedeAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medicine",
                table: "AppointmentSchedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Medicine",
                table: "AppointmentSchedules",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
