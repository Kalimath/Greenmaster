using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster.Core.Migrations
{
    public partial class AddedStaticDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placeables_Species_SpecieId",
                table: "Placeables");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Placeables_Species_SpecieId",
                table: "Placeables",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placeables_Species_SpecieId",
                table: "Placeables");

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

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.AddForeignKey(
                name: "FK_Placeables_Species_SpecieId",
                table: "Placeables",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
