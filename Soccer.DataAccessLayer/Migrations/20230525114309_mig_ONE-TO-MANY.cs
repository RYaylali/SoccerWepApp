using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soccer.DataAccessLayer.Migrations
{
    public partial class mig_ONETOMANY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamID",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Players");
        }
    }
}
