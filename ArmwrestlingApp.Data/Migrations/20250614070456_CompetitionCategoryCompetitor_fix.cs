using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmwrestlingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompetitionCategoryCompetitor_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionsCategories_Competitors_CompetitorId",
                table: "CompetitionsCategories");

            migrationBuilder.DropIndex(
                name: "IX_CompetitionsCategories_CompetitorId",
                table: "CompetitionsCategories");

            migrationBuilder.DropColumn(
                name: "CompetitorId",
                table: "CompetitionsCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompetitorId",
                table: "CompetitionsCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsCategories_CompetitorId",
                table: "CompetitionsCategories",
                column: "CompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionsCategories_Competitors_CompetitorId",
                table: "CompetitionsCategories",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "CompetitorId");
        }
    }
}
