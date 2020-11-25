using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class Transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageSizeCostId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_BeverageCost_BeverageSizeCostId",
                        column: x => x.BeverageSizeCostId,
                        principalSchema: "Data",
                        principalTable: "BeverageCost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BeverageSizeCostId",
                schema: "Data",
                table: "Transaction",
                column: "BeverageSizeCostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "Data");
        }
    }
}
