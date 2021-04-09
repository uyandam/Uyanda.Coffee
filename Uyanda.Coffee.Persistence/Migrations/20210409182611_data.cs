using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageSizeCostId = table.Column<int>(type: "int", nullable: false),
                    CurrencyCostPerItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currency_BeverageCost_BeverageSizeCostId",
                        column: x => x.BeverageSizeCostId,
                        principalSchema: "Data",
                        principalTable: "BeverageCost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Currency_Invoice_InvoiceEntityId",
                        column: x => x.InvoiceEntityId,
                        principalSchema: "Data",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_BeverageSizeCostId",
                schema: "Data",
                table: "Currency",
                column: "BeverageSizeCostId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_InvoiceEntityId",
                schema: "Data",
                table: "Currency",
                column: "InvoiceEntityId");
        }
    }
}
