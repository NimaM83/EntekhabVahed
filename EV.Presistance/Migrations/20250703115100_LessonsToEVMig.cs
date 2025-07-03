using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EV.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class LessonsToEVMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LessonsId",
                table: "EVs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonsId",
                table: "EVs");
        }
    }
}
