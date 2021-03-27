using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class currencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.CreateTable(
                name: "BeverageSizes",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeverageSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeverageTypeEntity",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeverageTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Points = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beverage",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageTypeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beverage_BeverageTypeEntity_BeverageTypeId",
                        column: x => x.BeverageTypeId,
                        principalSchema: "Data",
                        principalTable: "BeverageTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    IsRedeemingPoints = table.Column<bool>(nullable: false),
                    DiscountedPoints = table.Column<decimal>(nullable: false),
                    FinalInvoicePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Data",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeverageCost",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageId = table.Column<int>(nullable: false),
                    BeverageSizeId = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_BeverageCost_BeverageSizes_BeverageSizeId",
                        column: x => x.BeverageSizeId,
                        principalSchema: "Data",
                        principalTable: "BeverageSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DollarCostPerItem = table.Column<decimal>(nullable: false),
                    InvoiceEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currency_Invoice_InvoiceEntityId",
                        column: x => x.InvoiceEntityId,
                        principalSchema: "Data",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                schema: "Data",
                table: "BeverageSizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Small" },
                    { 2, "Medium" },
                    { 3, "Large" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "BeverageTypeEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hot" },
                    { 2, "Cold" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "Customer",
                columns: new[] { "Id", "PhoneNumber", "Points" },
                values: new object[] { 1, "0", 0m });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "Beverage",
                columns: new[] { "Id", "BeverageTypeId", "IsActive", "Name" },
                values: new object[] { 1, 1, true, "Coffee" });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "Beverage",
                columns: new[] { "Id", "BeverageTypeId", "IsActive", "Name" },
                values: new object[] { 2, 1, true, "Five Roses" });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "Beverage",
                columns: new[] { "Id", "BeverageTypeId", "IsActive", "Name" },
                values: new object[] { 3, 2, true, "Milkshake" });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "BeverageCost",
                columns: new[] { "Id", "BeverageId", "BeverageSizeId", "Cost" },
                values: new object[,]
                {
                    { 1, 1, 1, 15m },
                    { 4, 1, 2, 10m },
                    { 7, 1, 3, 20m },
                    { 2, 2, 1, 25m },
                    { 5, 2, 2, 15m },
                    { 8, 2, 3, 30m },
                    { 3, 3, 1, 30m },
                    { 6, 3, 2, 20m },
                    { 9, 3, 3, 40m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beverage_BeverageTypeId",
                schema: "Data",
                table: "Beverage",
                column: "BeverageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCost_BeverageSizeId",
                schema: "Data",
                table: "BeverageCost",
                column: "BeverageSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCost_BeverageId_BeverageSizeId",
                schema: "Data",
                table: "BeverageCost",
                columns: new[] { "BeverageId", "BeverageSizeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_InvoiceEntityId",
                schema: "Data",
                table: "Currency",
                column: "InvoiceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PhoneNumber",
                schema: "Data",
                table: "Customer",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                schema: "Data",
                table: "Invoice",
                column: "CustomerId");

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
                name: "Currency",
                schema: "Data");

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

            migrationBuilder.DropTable(
                name: "BeverageSizes",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "BeverageTypeEntity",
                schema: "Data");
        }
    }
}
