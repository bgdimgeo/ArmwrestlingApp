using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmwrestlingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique Id of the competition"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Competition Name"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Competition location name"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Brief information about the competition"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "Competition Type"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the competition starts"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the competition ends"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the competition was created"),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The last date on which the competionns was changed"),
                    Creator_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Competition created by"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Competition is deleted"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Url of the game image"),
                    Finished = table.Column<bool>(type: "bit", nullable: false, comment: "Competion is finished")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionsCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionsCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionsCategories_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsCategories_CategoryId",
                table: "CompetitionsCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsCategories_CompetitionId",
                table: "CompetitionsCategories",
                column: "CompetitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionsCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
