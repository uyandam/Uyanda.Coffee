using Microsoft.EntityFrameworkCore.Migrations;

namespace Uyanda.Coffee.Persistence.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.CreateTable(
                name: "Beverages",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    BeverageType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverages", x => x.Id);
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
                        name: "FK_BeverageCost_Beverages_BeverageId",
                        column: x => x.BeverageId,
                        principalSchema: "Data",
                        principalTable: "Beverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCost_BeverageId",
                schema: "Data",
                table: "BeverageCost",
                column: "BeverageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeverageCost",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Beverages",
                schema: "Data");
        }
    }
}
