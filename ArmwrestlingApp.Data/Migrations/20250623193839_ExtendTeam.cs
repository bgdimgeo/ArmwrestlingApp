using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmwrestlingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Name of the Country in which the team is");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Name of the Town in which the team is");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Teams");
        }
    }
}
