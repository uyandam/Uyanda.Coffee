using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class uniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BeverageCost_BeverageId",
                schema: "Data",
                table: "BeverageCost");

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCost_BeverageId_BeverageSizeId",
                schema: "Data",
                table: "BeverageCost",
                columns: new[] { "BeverageId", "BeverageSizeId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BeverageCost_BeverageId_BeverageSizeId",
                schema: "Data",
                table: "BeverageCost");

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCost_BeverageId",
                schema: "Data",
                table: "BeverageCost",
                column: "BeverageId");
        }
    }
}
