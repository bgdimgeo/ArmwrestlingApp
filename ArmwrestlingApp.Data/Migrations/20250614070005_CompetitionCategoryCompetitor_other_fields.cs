using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmwrestlingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompetitionCategoryCompetitor_other_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetitionsCategories",
                table: "CompetitionsCategories");

            migrationBuilder.DropIndex(
                name: "IX_CompetitionsCategories_CategoryId",
                table: "CompetitionsCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitionId",
                table: "CompetitionsCategories",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Id of the competition",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CompetitionsCategories",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Id of the category",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Changer_id",
                table: "Competitions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetitionsCategories",
                table: "CompetitionsCategories",
                columns: new[] { "CategoryId", "CompetitionId" });

            migrationBuilder.CreateTable(
                name: "CompetitionCategorieCompetitor",
                columns: table => new
                {
                    CompetitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of the competition"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of the category"),
                    CompetitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of the competitor"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unquq Id of the entry"),
                    Rank = table.Column<int>(type: "int", nullable: false, comment: "Place in the ranking "),
                    Wins = table.Column<int>(type: "int", nullable: false, comment: "Total Wins"),
                    Loses = table.Column<int>(type: "int", nullable: false, comment: "Total Loses"),
                    DrawNumber = table.Column<int>(type: "int", nullable: false, comment: "Number used for the draw in the category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionCategorieCompetitor", x => new { x.CompetitorId, x.CategoryId, x.CompetitionId });
                    table.ForeignKey(
                        name: "FK_CompetitionCategorieCompetitor_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionCategorieCompetitor_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionCategorieCompetitor_Competitors_CompetitorId",
                        column: x => x.CompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "CompetitorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Changer_id",
                table: "Competitions",
                column: "Changer_id");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionCategorieCompetitor_CategoryId",
                table: "CompetitionCategorieCompetitor",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionCategorieCompetitor_CompetitionId",
                table: "CompetitionCategorieCompetitor",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_AspNetUsers_Changer_id",
                table: "Competitions",
                column: "Changer_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_AspNetUsers_Changer_id",
                table: "Competitions");

            migrationBuilder.DropTable(
                name: "CompetitionCategorieCompetitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetitionsCategories",
                table: "CompetitionsCategories");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_Changer_id",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Changer_id",
                table: "Competitions");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitionId",
                table: "CompetitionsCategories",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Id of the competition");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CompetitionsCategories",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Id of the category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetitionsCategories",
                table: "CompetitionsCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsCategories_CategoryId",
                table: "CompetitionsCategories",
                column: "CategoryId");
        }
    }
}
