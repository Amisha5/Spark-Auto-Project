using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.DataLayer.Migrations
{
    public partial class AddedcolumninServiceDetailstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "CarServiceDetails",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ServicePrice",
                table: "CarServiceDetails",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "CarServiceDetails");

            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "CarServiceDetails");
        }
    }
}
