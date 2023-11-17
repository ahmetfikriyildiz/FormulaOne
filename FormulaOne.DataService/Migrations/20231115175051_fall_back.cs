using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class fall_back : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Achivements_AchivementsId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_AchivementsId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "AchivementsId",
                table: "Drivers");

            migrationBuilder.CreateIndex(
                name: "IX_Achivements_DriverId",
                table: "Achivements",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achivements_Drivers_DriverId",
                table: "Achivements",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achivements_Drivers_DriverId",
                table: "Achivements");

            migrationBuilder.DropIndex(
                name: "IX_Achivements_DriverId",
                table: "Achivements");

            migrationBuilder.AddColumn<Guid>(
                name: "AchivementsId",
                table: "Drivers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_AchivementsId",
                table: "Drivers",
                column: "AchivementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Achivements_AchivementsId",
                table: "Drivers",
                column: "AchivementsId",
                principalTable: "Achivements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
