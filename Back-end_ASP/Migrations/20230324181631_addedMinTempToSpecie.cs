using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster_ASP.Migrations
{
    public partial class addedMinTempToSpecie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinimalTemperature",
                table: "Species",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1,
                column: "MinimalTemperature",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "MinimalTemperature",
                value: -2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimalTemperature",
                table: "Species");
        }
    }
}
