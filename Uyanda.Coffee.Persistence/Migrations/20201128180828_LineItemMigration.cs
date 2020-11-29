using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class LineItemMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.CreateTable(
                name: "Beverage",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    BeverageType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverage", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "BeverageCost",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageId = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    BeverageSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeverageCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeverageCost_Beverage_BeverageId",
                        column: x => x.BeverageId,
                        principalSchema: "Data",
                        principalTable: "Beverage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageSizeCostId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CostPerItem = table.Column<decimal>(nullable: false),
                    InvoiceEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_BeverageCost_BeverageSizeCostId",
                        column: x => x.BeverageSizeCostId,
                        principalSchema: "Data",
                        principalTable: "BeverageCost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItem_Invoice_InvoiceEntityId",
                        column: x => x.InvoiceEntityId,
                        principalSchema: "Data",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCost_BeverageId",
                schema: "Data",
                table: "BeverageCost",
                column: "BeverageId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_BeverageSizeCostId",
                schema: "Data",
                table: "LineItem",
                column: "BeverageSizeCostId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_InvoiceEntityId",
                schema: "Data",
                table: "LineItem",
                column: "InvoiceEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "BeverageCost",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Beverage",
                schema: "Data");
        }
    }
}
