using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmwrestlingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addFinishedColumnInCompetitionCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "CompetitionsCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                table: "CompetitionsCategories");
        }
    }
}
