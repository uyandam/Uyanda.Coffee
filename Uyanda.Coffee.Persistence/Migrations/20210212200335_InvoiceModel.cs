using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class InvoiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPoints",
                schema: "Data",
                table: "Invoice",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalInvoicePrice",
                schema: "Data",
                table: "Invoice",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsRedeemingPoints",
                schema: "Data",
                table: "Invoice",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountedPoints",
                schema: "Data",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "FinalInvoicePrice",
                schema: "Data",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "IsRedeemingPoints",
                schema: "Data",
                table: "Invoice");
        }
    }
}
