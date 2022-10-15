using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class renamePayTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pay_Invoice_InvoiceId",
                schema: "Data",
                table: "Pay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pay",
                schema: "Data",
                table: "Pay");

            migrationBuilder.RenameTable(
                name: "Pay",
                schema: "Data",
                newName: "Payment",
                newSchema: "Data");

            migrationBuilder.RenameIndex(
                name: "IX_Pay_InvoiceId",
                schema: "Data",
                table: "Payment",
                newName: "IX_Payment_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                schema: "Data",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Invoice_InvoiceId",
                schema: "Data",
                table: "Payment",
                column: "InvoiceId",
                principalSchema: "Data",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Invoice_InvoiceId",
                schema: "Data",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                schema: "Data",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "Data",
                newName: "Pay",
                newSchema: "Data");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_InvoiceId",
                schema: "Data",
                table: "Pay",
                newName: "IX_Pay_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pay",
                schema: "Data",
                table: "Pay",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_Invoice_InvoiceId",
                schema: "Data",
                table: "Pay",
                column: "InvoiceId",
                principalSchema: "Data",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
