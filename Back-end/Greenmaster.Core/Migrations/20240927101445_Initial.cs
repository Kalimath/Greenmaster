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

            migrationBuilder.InsertData(
                table: "GardenStyles",
                columns: new[] { "Id", "AllSeasonInterest", "Colors", "Concepts", "Description", "DivideIntoRooms", "Name", "PathSize", "RequiresLargeGarden", "Shapes", "SuitablePlantGenera" },
                values: new object[,]
                {
                    { 1, false, "0x000000A4,0x0000004F,0x00000025", "StraightLines,Geometric", "If you love sharp, clean lines, clutter-free spaces and a contemporary feel, then modern and minimal garden design is perfect for you.", false, "Modern and minimal", 0, false, "Round,Cubic", "Ginkgo" },
                    { 2, true, "0x0000008D,0x000000A6,0x00000025,0x0000007F,0x000000A2,0x0000004F,0x000000A4,0x0000005F,0x0000004E,0x00000023,0x00000027", "Herbaceous,Topiary,Sculptured,Colorful", "Wide paths, deep herbaceous borders, structures, pools, rills, structures, terraces and lavishly planted pots.", true, "English country", 2, true, "NotSet", "Iris,Delphinium,Rosa" },
                    { 3, true, "0x0000008D,0x000000A6,0x00000025,0x0000007F,0x000000A2,0x0000004F,0x000000A7,0x000000A1,0x00000080,0x0000004D,0x00000026,0x0000008C,0x000000A4,0x0000005F,0x0000004E,0x00000023,0x00000027", "Herbaceous,Cramped,Topiary,Sculptured,NoLawn,Colorful,SelfSeeding,Geometric", "Cottage gardens are made up of a mix of colours, as opposed to a strict colour scheme. Cottage gardens are also likely to make use of self-seeding plants such as foxgloves and aquilegias, which pop up spontaneously around the garden or in cracks in paving, adding to the informal look.", true, "Cottage", 0, false, "NotSet", "Aquilegia,Geranium,Phlox,Delphinium,Lupinus,Lonicera,Campanula,Lavandula,Alcea,Paeonia,Rosa,Allium,Tulipa,Narcissus,Clematis,Alchemilla,Dianthus,Digitalis,Lathyrus,Aster,Malva" }
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

            migrationBuilder.InsertData(
                table: "ObjectTypes",
                columns: new[] { "Id", "AllowAsUndergrowth", "Canopy", "Description", "Name", "objectType_type" },
                values: new object[,]
                {
                    { 1, false, "Closed", "Hedges are rows of closely planted shrubs, and come in all shapes, styles and sizes.", "Hedge", "PlantType" },
                    { 2, false, "Closed", "Trees have a permanent woody structure – usually a single trunk and a network of branches. Some grow quite large, but there are plenty of smaller options too. Most offer an array of attractive features, including decorative foliage, flowers, fruits and bark. Some keep their leaves all year, while others are leafless over winter.", "Tree", "PlantType" },
                    { 3, true, "Partial", "These plants clothe walls and supports in foliage and flowers. Climbers cling on using tendrils, twining stems, stem roots or sticky pads, while wall shrubs need to be tied to supports. Plants can be large and vigorous or neat and compact, some are evergreen retaining their foliage all year, while others are deciduous and lose their leaves over winter. ", "Climber", "PlantType" },
                    { 4, true, "Partial", "Small shrubs have a permanent structure of woody stems. They come in all shapes, some holding onto their leaves all year, others losing them in autumn. As well as flowers in every possible hue, many shrubs have attractive foliage and fruits.", "Small shrub (<2 metres)", "PlantType" },
                    { 5, true, "Partial", "Large shrubs have a permanent structure of woody stems. They come in all shapes, some holding onto their leaves all year, others losing them in autumn. As well as flowers in every possible hue, many shrubs have attractive foliage, fruits and bark.", "Large shrub (2-8 metres)", "PlantType" },
                    { 6, true, "NotSet", "Versatile, hardy and spectacular, bringing movement, texture and drama to gardens of all styles, nearly all year round.", "Grass", "PlantType" },
                    { 7, true, "Closed", "Ferns can be large or small, often with elegantly arching, feathery foliage. The plants usually have a shuttlecock shape, with new growth unfurling from the centre. Deciduous types die down in winter, while evergreen and semi-evergreen have a year-round presence.", "Fern", "PlantType" },
                    { 8, true, "Partial", "Aquatic and bog plants tend to be big and bold, lush and leafy, with brightly coloured flowers. Some aquatics spread out across the pond’s surface, while others grow vertically out of the water.", "Aquatic", "PlantType" },
                    { 9, true, "Partial", "It includes a wide range of flower shapes, colours and sizes as this is a large and diverse group.", "Bulb", "PlantType" },
                    { 10, false, "NotSet", "They come in a huge range of shapes, colours and forms, some covered in spines, others smooth or furry, some gently rounded, others angular and sculptural.", "Succulent", "PlantType" },
                    { 11, false, "Open", "They come in a huge range of shapes, colours and forms, some covered in spines, others smooth or furry, some gently rounded, others angular and sculptural.", "Cactus", "PlantType" }
                });

            migrationBuilder.InsertData(
                table: "ObjectTypes",
                columns: new[] { "Id", "Description", "Name", "objectType_type" },
                values: new object[,]
                {
                    { 100, "/", "Swimming pool", "StructureType" },
                    { 101, "/", "Pond", "StructureType" },
                    { 102, "/", "Garage", "StructureType" },
                    { 103, "/", "Swing", "StructureType" },
                    { 104, "/", "Animal pen", "StructureType" },
                    { 105, "/", "Shed", "StructureType" }
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
