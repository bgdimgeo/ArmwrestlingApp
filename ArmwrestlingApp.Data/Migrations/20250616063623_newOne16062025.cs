using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmwrestlingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class newOne16062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionCategorieCompetitor_Categories_CategoryId",
                table: "CompetitionCategorieCompetitor");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionCategorieCompetitor_Competitions_CompetitionId",
                table: "CompetitionCategorieCompetitor");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionCategorieCompetitor_Competitors_CompetitorId",
                table: "CompetitionCategorieCompetitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetitionCategorieCompetitor",
                table: "CompetitionCategorieCompetitor");

            migrationBuilder.RenameTable(
                name: "CompetitionCategorieCompetitor",
                newName: "CompetitionCategorieCompetitors");

            migrationBuilder.RenameIndex(
                name: "IX_CompetitionCategorieCompetitor_CompetitionId",
                table: "CompetitionCategorieCompetitors",
                newName: "IX_CompetitionCategorieCompetitors_CompetitionId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetitionCategorieCompetitor_CategoryId",
                table: "CompetitionCategorieCompetitors",
                newName: "IX_CompetitionCategorieCompetitors_CategoryId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Team");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Competitors",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Competitor is deleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompetitionsCategories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Category is deleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Category is deleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompetitionCategorieCompetitors",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Category is deleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetitionCategorieCompetitors",
                table: "CompetitionCategorieCompetitors",
                columns: new[] { "CompetitorId", "CategoryId", "CompetitionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionCategorieCompetitors_Categories_CategoryId",
                table: "CompetitionCategorieCompetitors",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionCategorieCompetitors_Competitions_CompetitionId",
                table: "CompetitionCategorieCompetitors",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionCategorieCompetitors_Competitors_CompetitorId",
                table: "CompetitionCategorieCompetitors",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "CompetitorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionCategorieCompetitors_Categories_CategoryId",
                table: "CompetitionCategorieCompetitors");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionCategorieCompetitors_Competitions_CompetitionId",
                table: "CompetitionCategorieCompetitors");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionCategorieCompetitors_Competitors_CompetitorId",
                table: "CompetitionCategorieCompetitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetitionCategorieCompetitors",
                table: "CompetitionCategorieCompetitors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Competitors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompetitionsCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompetitionCategorieCompetitors");

            migrationBuilder.RenameTable(
                name: "CompetitionCategorieCompetitors",
                newName: "CompetitionCategorieCompetitor");

            migrationBuilder.RenameIndex(
                name: "IX_CompetitionCategorieCompetitors_CompetitionId",
                table: "CompetitionCategorieCompetitor",
                newName: "IX_CompetitionCategorieCompetitor_CompetitionId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetitionCategorieCompetitors_CategoryId",
                table: "CompetitionCategorieCompetitor",
                newName: "IX_CompetitionCategorieCompetitor_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetitionCategorieCompetitor",
                table: "CompetitionCategorieCompetitor",
                columns: new[] { "CompetitorId", "CategoryId", "CompetitionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionCategorieCompetitor_Categories_CategoryId",
                table: "CompetitionCategorieCompetitor",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionCategorieCompetitor_Competitions_CompetitionId",
                table: "CompetitionCategorieCompetitor",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionCategorieCompetitor_Competitors_CompetitorId",
                table: "CompetitionCategorieCompetitor",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "CompetitorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
