using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster_ASP.Migrations
{
    public partial class AddedSeedDataForMaterialTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialTypes_GardenStyles_GardenStyleId",
                table: "MaterialTypes");

            migrationBuilder.DropIndex(
                name: "IX_MaterialTypes_GardenStyleId",
                table: "MaterialTypes");

            migrationBuilder.DropColumn(
                name: "GardenStyleId",
                table: "MaterialTypes");

            migrationBuilder.CreateTable(
                name: "GardenStyleMaterialTypes",
                columns: table => new
                {
                    GardenStylesId = table.Column<int>(type: "integer", nullable: false),
                    MaterialsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenStyleMaterialTypes", x => new { x.GardenStylesId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_GardenStyleMaterialTypes_GardenStyles_GardenStylesId",
                        column: x => x.GardenStylesId,
                        principalTable: "GardenStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenStyleMaterialTypes_MaterialTypes_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Wood", "Wood" },
                    { 2, "Stone", "Stone" },
                    { 3, "Brick", "Brick" },
                    { 4, "Corten steel, is a group of steel alloys which were developed to eliminate the need for painting, and form a stable rust-like appearance.", "Corten steel" },
                    { 5, "A gabion is a cage, cylinder or box filled with rocks, concrete, or sometimes sand and soil.", "Gabion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenStyleMaterialTypes_MaterialsId",
                table: "GardenStyleMaterialTypes",
                column: "MaterialsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenStyleMaterialTypes");

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "GardenStyleId",
                table: "MaterialTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTypes_GardenStyleId",
                table: "MaterialTypes",
                column: "GardenStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialTypes_GardenStyles_GardenStyleId",
                table: "MaterialTypes",
                column: "GardenStyleId",
                principalTable: "GardenStyles",
                principalColumn: "Id");
        }
    }
}
