using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EV.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChartId",
                table: "LessonGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonGroups_ChartId",
                table: "LessonGroups",
                column: "ChartId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonGroups_Charts_ChartId",
                table: "LessonGroups",
                column: "ChartId",
                principalTable: "Charts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonGroups_Charts_ChartId",
                table: "LessonGroups");

            migrationBuilder.DropIndex(
                name: "IX_LessonGroups_ChartId",
                table: "LessonGroups");

            migrationBuilder.DropColumn(
                name: "ChartId",
                table: "LessonGroups");
        }
    }
}
