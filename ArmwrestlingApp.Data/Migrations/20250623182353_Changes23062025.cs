using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmwrestlingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changes23062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CompetitionsCategories",
                type: "bit",
                nullable: false,
                comment: "Not assigned",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Category is deleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CompetitionsCategories",
                type: "bit",
                nullable: false,
                comment: "Category is deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Not assigned");
        }
    }
}
