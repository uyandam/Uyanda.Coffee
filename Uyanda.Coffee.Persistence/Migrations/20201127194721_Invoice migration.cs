using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class Invoicemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceEntityId",
                schema: "Data",
                table: "Transaction",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_InvoiceEntityId",
                schema: "Data",
                table: "Transaction",
                column: "InvoiceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Invoice_InvoiceEntityId",
                schema: "Data",
                table: "Transaction",
                column: "InvoiceEntityId",
                principalSchema: "Data",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Invoice_InvoiceEntityId",
                schema: "Data",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_InvoiceEntityId",
                schema: "Data",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "InvoiceEntityId",
                schema: "Data",
                table: "Transaction");
        }
    }
}
