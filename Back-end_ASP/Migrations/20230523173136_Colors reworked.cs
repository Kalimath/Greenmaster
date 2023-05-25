using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster_ASP.Migrations
{
    public partial class Colorsreworked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Colors",
                value: new[] { "Color [White]", "Color [Green]", "Color [Blue]" });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1,
                column: "FlowerColors",
                value: "Color [Blue],Color [Orange]");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "FlowerColors",
                value: "Color [Pink]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Colors",
                value: new[] { "White", "Green", "Blue" });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1,
                column: "FlowerColors",
                value: "Blue,MultiColor,Orange");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "FlowerColors",
                value: "Pink");
        }
    }
}
