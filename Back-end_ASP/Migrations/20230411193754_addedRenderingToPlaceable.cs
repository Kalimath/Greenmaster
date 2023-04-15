using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenmaster_ASP.Migrations
{
    public partial class addedRenderingToPlaceable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Placeables",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Placeables",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "RenderingId",
                table: "Placeables",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Placeables",
                keyColumn: "Id",
                keyValue: new Guid("6f8fb151-fd51-45eb-8d98-764effc7107e"),
                columns: new[] { "Modified", "RenderingId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Placeables",
                keyColumn: "Id",
                keyValue: new Guid("be6fd31e-38a6-400f-98c7-3c56c3207273"),
                column: "RenderingId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Placeables",
                keyColumn: "Id",
                keyValue: new Guid("c5dd401a-9898-48e2-aef5-6fa102a79e29"),
                columns: new[] { "Modified", "RenderingId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Placeables_RenderingId",
                table: "Placeables",
                column: "RenderingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Placeables_Renderings_RenderingId",
                table: "Placeables",
                column: "RenderingId",
                principalTable: "Renderings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placeables_Renderings_RenderingId",
                table: "Placeables");

            migrationBuilder.DropIndex(
                name: "IX_Placeables_RenderingId",
                table: "Placeables");

            migrationBuilder.DropColumn(
                name: "RenderingId",
                table: "Placeables");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Placeables",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Placeables",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "Placeables",
                keyColumn: "Id",
                keyValue: new Guid("6f8fb151-fd51-45eb-8d98-764effc7107e"),
                column: "Modified",
                value: new DateTime(2023, 4, 9, 16, 49, 11, 955, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Placeables",
                keyColumn: "Id",
                keyValue: new Guid("c5dd401a-9898-48e2-aef5-6fa102a79e29"),
                column: "Modified",
                value: new DateTime(2023, 4, 9, 16, 49, 11, 955, DateTimeKind.Local).AddTicks(2625));
        }
    }
}
