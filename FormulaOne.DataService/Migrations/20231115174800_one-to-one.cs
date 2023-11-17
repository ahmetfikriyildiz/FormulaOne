using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class onetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchivementDriver");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
