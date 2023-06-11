using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster.Core.Migrations
{
    public partial class AdjustedColorPallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Colors",
                value: new[] { "Red", "Yellow", "Blue", "Orange", "Violet", "Green", "White", "LightGray", "Gray", "Black", "Brown" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Colors",
                value: new[] { "Red", "Yellow", "Blue", "Orange", "Violet", "Green", "YellowGreen", "Turquoise", "OrangeRed", "Goldenrod", "BlueViolet", "Purple", "White", "LightGray", "Gray", "Black", "Brown" });
        }
    }
}
