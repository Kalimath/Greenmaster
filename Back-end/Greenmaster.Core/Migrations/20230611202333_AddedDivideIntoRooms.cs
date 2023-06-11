using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster.Core.Migrations
{
    public partial class AddedDivideIntoRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DivideIntoRooms",
                table: "GardenStyles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Concepts",
                value: new[] { "StraightLines", "Geometric" });

            migrationBuilder.InsertData(
                table: "GardenStyles",
                columns: new[] { "Id", "AllSeasonInterest", "Colors", "Concepts", "Description", "DivideIntoRooms", "Name", "PathSize", "RequiresLargeGarden", "Shapes" },
                values: new object[] { 2, true, new[] { "Red", "Yellow", "Blue", "Orange", "Violet", "Green", "YellowGreen", "Turquoise", "OrangeRed", "Goldenrod", "BlueViolet", "Purple", "White", "LightGray", "Gray", "Black", "Brown" }, new[] { "Herbaceous", "Topiary", "Sculptured", "Colorful" }, "Wide paths, deep herbaceous borders, structures, pools, rills, structures, terraces and lavishly planted pots.", true, "English country", 2, true, new[] { "NotSet" } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DivideIntoRooms",
                table: "GardenStyles");

            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Concepts",
                value: new[] { "StraightLines", "CurvedLines" });
        }
    }
}
