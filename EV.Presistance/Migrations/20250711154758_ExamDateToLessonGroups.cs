using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EV.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class ExamDateToLessonGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExamDate",
                table: "LessonGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamDate",
                table: "LessonGroups");
        }
    }
}
