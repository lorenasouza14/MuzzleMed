using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuzzleMedBackend.Migrations
{
    /// <inheritdoc />
    public partial class AdiconandoCamposNoAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Medicine",
                table: "AppointmentSchedules",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SymptomDescription",
                table: "AppointmentSchedules",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medicine",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "SymptomDescription",
                table: "AppointmentSchedules");
        }
    }
}
