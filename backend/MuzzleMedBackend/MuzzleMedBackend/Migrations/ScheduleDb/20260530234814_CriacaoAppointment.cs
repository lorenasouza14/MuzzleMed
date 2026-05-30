using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuzzleMedBackend.Migrations.ScheduleDb
{
    /// <inheritdoc />
    public partial class CriacaoAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppointmentSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PetId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClinicId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VetId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSchedules", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_ClinicId",
                table: "AppointmentSchedules",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_PetId",
                table: "AppointmentSchedules",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_UserId",
                table: "AppointmentSchedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_VetId",
                table: "AppointmentSchedules",
                column: "VetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSchedules");
        }
    }
}
