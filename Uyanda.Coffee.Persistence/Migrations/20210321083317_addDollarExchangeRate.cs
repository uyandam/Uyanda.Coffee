using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class addDollarExchangeRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeverageSizeCostId",
                schema: "Data",
                table: "Currency",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_BeverageSizeCostId",
                schema: "Data",
                table: "Currency",
                column: "BeverageSizeCostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_BeverageCost_BeverageSizeCostId",
                schema: "Data",
                table: "Currency",
                column: "BeverageSizeCostId",
                principalSchema: "Data",
                principalTable: "BeverageCost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currency_BeverageCost_BeverageSizeCostId",
                schema: "Data",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Currency_BeverageSizeCostId",
                schema: "Data",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "BeverageSizeCostId",
                schema: "Data",
                table: "Currency");
        }
    }
}
