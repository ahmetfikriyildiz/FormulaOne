using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achivements_Driver",
                table: "Achivements");

            migrationBuilder.DropIndex(
                name: "IX_Achivements_DriverId",
                table: "Achivements");

            migrationBuilder.CreateTable(
                name: "AchivementDriver",
                columns: table => new
                {
                    AchivementsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DriversId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchivementDriver", x => new { x.AchivementsId, x.DriversId });
                    table.ForeignKey(
                        name: "FK_AchivementDriver_Achivements_AchivementsId",
                        column: x => x.AchivementsId,
                        principalTable: "Achivements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AchivementDriver_Drivers_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AchivementDriver_DriversId",
                table: "AchivementDriver",
                column: "DriversId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchivementDriver");

            migrationBuilder.CreateIndex(
                name: "IX_Achivements_DriverId",
                table: "Achivements",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achivements_Driver",
                table: "Achivements",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }
    }
}
