using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuzzleMedBackend.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoIsActiveEmPetSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PetsSchedule",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PetsSchedule");
        }
    }
}
