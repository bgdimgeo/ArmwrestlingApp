using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmwrestlingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixCategoryCompetionCreatorChanger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Changer_id",
                table: "Competitions",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Competition changed by",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Changer_id",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Competition changed by");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date on which the category was created");

            migrationBuilder.AddColumn<Guid>(
                name: "Creator_id",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Competition created by");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                comment: "The last date on which the cartegory was changed");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Creator_id",
                table: "Competitions",
                column: "Creator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Changer_id",
                table: "Categories",
                column: "Changer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Creator_id",
                table: "Categories",
                column: "Creator_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_Changer_id",
                table: "Categories",
                column: "Changer_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_Creator_id",
                table: "Categories",
                column: "Creator_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_AspNetUsers_Creator_id",
                table: "Competitions",
                column: "Creator_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_Changer_id",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_Creator_id",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_AspNetUsers_Creator_id",
                table: "Competitions");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_Creator_id",
                table: "Competitions");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Changer_id",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Creator_id",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Changer_id",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Creator_id",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "Categories");

            migrationBuilder.AlterColumn<Guid>(
                name: "Changer_id",
                table: "Competitions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Competition changed by");
        }
    }
}
