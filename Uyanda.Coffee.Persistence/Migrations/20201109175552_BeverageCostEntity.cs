using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class BeverageCostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeverageCost",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageIdId = table.Column<int>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    BeverageSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeverageCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeverageCost_Beverage_BeverageIdId",
                        column: x => x.BeverageIdId,
                        principalSchema: "Data",
                        principalTable: "Beverage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCost_BeverageIdId",
                schema: "Data",
                table: "BeverageCost",
                column: "BeverageIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeverageCost",
                schema: "Data");
        }
    }
}
