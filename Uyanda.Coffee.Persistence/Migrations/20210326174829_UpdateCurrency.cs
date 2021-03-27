using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class UpdateCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DollarCostPerItem",
                schema: "Data",
                table: "Currency");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyCostPerItem",
                schema: "Data",
                table: "Currency",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCostPerItem",
                schema: "Data",
                table: "Currency");

            migrationBuilder.AddColumn<decimal>(
                name: "DollarCostPerItem",
                schema: "Data",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
