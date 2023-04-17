using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster_ASP.Migrations
{
    public partial class addedPlaceableSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Placeables",
                columns: new[] { "Id", "Created", "DimensionsId", "Discriminator", "LocationId", "Modified", "Name", "SpecieId", "TypeId" },
                values: new object[,]
                {
                    { new Guid("6f8fb151-fd51-45eb-8d98-764effc7107e"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Plant", 22, new DateTime(2023, 4, 9, 16, 49, 11, 955, DateTimeKind.Local).AddTicks(2341), "Papaver Orientale 'Catherina' (mature)", 2, 4 },
                    { new Guid("be6fd31e-38a6-400f-98c7-3c56c3207273"), new DateTime(2020, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Plant", 21, new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strelitzia Reginae (mature)", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Placeables",
                columns: new[] { "Id", "Created", "DimensionsId", "Discriminator", "LocationId", "Modified", "Name", "TypeId" },
                values: new object[] { new Guid("c5dd401a-9898-48e2-aef5-6fa102a79e29"), new DateTime(2020, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Structure", 22, new DateTime(2023, 4, 9, 16, 49, 11, 955, DateTimeKind.Local).AddTicks(2625), "Large swimming pool", 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Placeables",
                keyColumn: "Id",
                keyValue: new Guid("6f8fb151-fd51-45eb-8d98-764effc7107e"));

            migrationBuilder.DeleteData(
                table: "Placeables",
                keyColumn: "Id",
                keyValue: new Guid("be6fd31e-38a6-400f-98c7-3c56c3207273"));

            migrationBuilder.DeleteData(
                table: "Placeables",
                keyColumn: "Id",
                keyValue: new Guid("c5dd401a-9898-48e2-aef5-6fa102a79e29"));
        }
    }
}
