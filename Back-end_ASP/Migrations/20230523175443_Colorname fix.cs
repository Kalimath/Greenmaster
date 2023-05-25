using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster_ASP.Migrations
{
    public partial class Colornamefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1,
                column: "FlowerColors",
                value: "Blue,Orange");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "FlowerColors",
                value: "Pink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
