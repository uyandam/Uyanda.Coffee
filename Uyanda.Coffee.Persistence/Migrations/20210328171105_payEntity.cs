using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class payEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pay_InvoiceId",
                schema: "Data",
                table: "Pay");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_InvoiceId",
                schema: "Data",
                table: "Pay",
                column: "InvoiceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pay_InvoiceId",
                schema: "Data",
                table: "Pay");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_InvoiceId",
                schema: "Data",
                table: "Pay",
                column: "InvoiceId");
        }
    }
}
