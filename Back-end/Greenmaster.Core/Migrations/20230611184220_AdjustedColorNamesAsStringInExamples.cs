using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster.Core.Migrations
{
    public partial class AdjustedColorNamesAsStringInExamples : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Colors",
                value: new[] { "White", "Green", "Blue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Colors",
                value: new[] { "Color [White]", "Color [Green]", "Color [Blue]" });
        }
    }
}
