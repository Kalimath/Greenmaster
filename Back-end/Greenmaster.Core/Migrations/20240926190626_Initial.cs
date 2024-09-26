using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GardenStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concepts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shapes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresLargeGarden = table.Column<bool>(type: "bit", nullable: false),
                    AllSeasonInterest = table.Column<bool>(type: "bit", nullable: false),
                    DivideIntoRooms = table.Column<bool>(type: "bit", nullable: false),
                    PathSize = table.Column<int>(type: "int", nullable: false),
                    SuitablePlantGenera = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    objectType_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Canopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowAsUndergrowth = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    Z = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Renderings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renderings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GardenStyleMaterialType",
                columns: table => new
                {
                    GardenStylesId = table.Column<int>(type: "int", nullable: false),
                    MaterialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenStyleMaterialType", x => new { x.GardenStylesId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_GardenStyleMaterialType_GardenStyles_GardenStylesId",
                        column: x => x.GardenStylesId,
                        principalTable: "GardenStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenStyleMaterialType_MaterialTypes_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cultivar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantTypeId = table.Column<int>(type: "int", nullable: false),
                    IsPoisonous = table.Column<bool>(type: "bit", nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sunlight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Water = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Climate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimalTemperature = table.Column<int>(type: "int", nullable: false),
                    MaxHeight = table.Column<double>(type: "float", nullable: false),
                    MaxWidth = table.Column<double>(type: "float", nullable: false),
                    MutualisticGenera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloomPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerColors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFragrant = table.Column<bool>(type: "bit", nullable: false),
                    PollinatingFlowers = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_ObjectTypes_PlantTypeId",
                        column: x => x.PlantTypeId,
                        principalTable: "ObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placeables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    DimensionsId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    RenderingId = table.Column<int>(type: "int", nullable: false),
                    placeable_filler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecieId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placeables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placeables_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placeables_ObjectTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placeables_Points_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Points",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Placeables_Renderings_RenderingId",
                        column: x => x.RenderingId,
                        principalTable: "Renderings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placeables_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenStyleMaterialType_MaterialsId",
                table: "GardenStyleMaterialType",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Placeables_DimensionsId",
                table: "Placeables",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Placeables_LocationId",
                table: "Placeables",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Placeables_RenderingId",
                table: "Placeables",
                column: "RenderingId");

            migrationBuilder.CreateIndex(
                name: "IX_Placeables_SpecieId",
                table: "Placeables",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Placeables_TypeId",
                table: "Placeables",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_PlantTypeId",
                table: "Species",
                column: "PlantTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenStyleMaterialType");

            migrationBuilder.DropTable(
                name: "Placeables");

            migrationBuilder.DropTable(
                name: "GardenStyles");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Renderings");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "ObjectTypes");
        }
    }
}
