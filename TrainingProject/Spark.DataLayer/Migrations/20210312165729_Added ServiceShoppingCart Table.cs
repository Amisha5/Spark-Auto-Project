using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.DataLayer.Migrations
{
    public partial class AddedServiceShoppingCartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    ServiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceShoppingCarts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceShoppingCarts_CarServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "CarServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceShoppingCarts_CarId",
                table: "ServiceShoppingCarts",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceShoppingCarts_ServiceTypeId",
                table: "ServiceShoppingCarts",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceShoppingCarts");
        }
    }
}
