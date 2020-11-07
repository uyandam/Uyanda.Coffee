using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class BeverageCostSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeverageSizeCostEntities",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(nullable: false),
                    BeverageIdId = table.Column<int>(nullable: true),
                    BeverageSizeIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeverageSizeCostEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeverageSizeCostEntities_Beverage_BeverageIdId",
                        column: x => x.BeverageIdId,
                        principalSchema: "Data",
                        principalTable: "Beverage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeverageSizeCostEntities_BeverageSizes_BeverageSizeIdId",
                        column: x => x.BeverageSizeIdId,
                        principalSchema: "Data",
                        principalTable: "BeverageSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeverageSizeCostEntities_BeverageIdId",
                schema: "Data",
                table: "BeverageSizeCostEntities",
                column: "BeverageIdId");

            migrationBuilder.CreateIndex(
                name: "IX_BeverageSizeCostEntities_BeverageSizeIdId",
                schema: "Data",
                table: "BeverageSizeCostEntities",
                column: "BeverageSizeIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeverageSizeCostEntities",
                schema: "Data");
        }
    }
}
