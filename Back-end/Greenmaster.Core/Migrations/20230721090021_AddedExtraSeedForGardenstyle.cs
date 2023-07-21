using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster.Core.Migrations
{
    public partial class AddedExtraSeedForGardenstyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GardenStyles",
                columns: new[] { "Id", "AllSeasonInterest", "Colors", "Concepts", "Description", "DivideIntoRooms", "Name", "PathSize", "RequiresLargeGarden", "Shapes", "SuitablePlantGenera" },
                values: new object[] { 3, true, new[] { "Red", "Yellow", "Blue", "Orange", "Violet", "Green", "White", "LightGray", "Gray", "Black", "Brown" }, new[] { "Herbaceous", "Cramped", "Topiary", "Sculptured", "NoLawn", "Colorful", "SelfSeeding", "Geometric" }, "Cottage gardens are made up of a mix of colours, as opposed to a strict colour scheme. Cottage gardens are also likely to make use of self-seeding plants such as foxgloves and aquilegias, which pop up spontaneously around the garden or in cracks in paving, adding to the informal look.", true, "Cottage", 0, false, new[] { "NotSet" }, "Aquilegia,Geranium,Phlox,Delphinium,Lupinus,Lonicera,Campanula,Lavandula,Alcea,Paeonia,Rosa,Allium,Tulipa,Narcissus,Clematis,Alchemilla,Dianthus,Digitalis,Lathyrus,Aster,Malva" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GardenStyles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
