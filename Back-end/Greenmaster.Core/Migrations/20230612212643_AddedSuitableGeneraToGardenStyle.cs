using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster.Core.Migrations
{
    public partial class AddedSuitableGeneraToGardenStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SuitablePlantGenera",
                table: "GardenStyles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SuitablePlantGenera",
                value: "Ginkgo");

            migrationBuilder.UpdateData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SuitablePlantGenera",
                value: "Iris,Delphinium,Rosa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuitablePlantGenera",
                table: "GardenStyles");
        }
    }
}
