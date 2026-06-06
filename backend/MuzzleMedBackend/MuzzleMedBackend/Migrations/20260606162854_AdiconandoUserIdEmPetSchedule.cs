using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuzzleMedBackend.Migrations
{
    /// <inheritdoc />
    public partial class AdiconandoUserIdEmPetSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PetsSchedule",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "HistoricAppointments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "HistoricAppointments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PetsSchedule_UserId",
                table: "PetsSchedule",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PetsSchedule_UserId",
                table: "PetsSchedule");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PetsSchedule");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "HistoricAppointments");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "HistoricAppointments");
        }
    }
}
