using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class Beverage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeverageType",
                schema: "Data",
                table: "Beverage");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Data",
                table: "Beverage");

            migrationBuilder.AddColumn<int>(
                name: "BeverageTypeEntityId",
                schema: "Data",
                table: "Beverage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beverage_BeverageTypeEntityId",
                schema: "Data",
                table: "Beverage",
                column: "BeverageTypeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beverage_BeverageTypes_BeverageTypeEntityId",
                schema: "Data",
                table: "Beverage",
                column: "BeverageTypeEntityId",
                principalSchema: "Data",
                principalTable: "BeverageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beverage_BeverageTypes_BeverageTypeEntityId",
                schema: "Data",
                table: "Beverage");

            migrationBuilder.DropIndex(
                name: "IX_Beverage_BeverageTypeEntityId",
                schema: "Data",
                table: "Beverage");

            migrationBuilder.DropColumn(
                name: "BeverageTypeEntityId",
                schema: "Data",
                table: "Beverage");

            migrationBuilder.AddColumn<int>(
                name: "BeverageType",
                schema: "Data",
                table: "Beverage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Data",
                table: "Beverage",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
