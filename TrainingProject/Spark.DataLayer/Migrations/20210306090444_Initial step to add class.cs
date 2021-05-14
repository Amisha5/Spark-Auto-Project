using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.DataLayer.Migrations
{
    public partial class Initialsteptoaddclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Style = table.Column<string>(nullable: false),
                    YearCount = table.Column<int>(nullable: false),
                    Miles = table.Column<double>(nullable: false),
                    CarColor = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "CarServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarServiceHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miles = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServiceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarServiceHistories_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarServiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceHistoryId = table.Column<int>(nullable: false),
                    ServiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarServiceDetails_CarServiceHistories_ServiceHistoryId",
                        column: x => x.ServiceHistoryId,
                        principalTable: "CarServiceHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarServiceDetails_CarServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "CarServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarServiceDetails_ServiceHistoryId",
                table: "CarServiceDetails",
                column: "ServiceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CarServiceDetails_ServiceTypeId",
                table: "CarServiceDetails",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarServiceHistories_CarId",
                table: "CarServiceHistories",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarServiceDetails");

            migrationBuilder.DropTable(
                name: "CarServiceHistories");

            migrationBuilder.DropTable(
                name: "CarServiceTypes");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
