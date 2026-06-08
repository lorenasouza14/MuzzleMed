using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuzzleMedBackend.Migrations
{
    /// <inheritdoc />
    public partial class AlteracoesNoHistoric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "HistoricAppointments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "ClinicName",
                table: "HistoricAppointments",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PetName",
                table: "HistoricAppointments",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SymptomDescription",
                table: "HistoricAppointments",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "VetId",
                table: "HistoricAppointments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "VetName",
                table: "HistoricAppointments",
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
                name: "ClinicId",
                table: "HistoricAppointments");

            migrationBuilder.DropColumn(
                name: "ClinicName",
                table: "HistoricAppointments");

            migrationBuilder.DropColumn(
                name: "PetName",
                table: "HistoricAppointments");

            migrationBuilder.DropColumn(
                name: "SymptomDescription",
                table: "HistoricAppointments");

            migrationBuilder.DropColumn(
                name: "VetId",
                table: "HistoricAppointments");

            migrationBuilder.DropColumn(
                name: "VetName",
                table: "HistoricAppointments");
        }
    }
}
