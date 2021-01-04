using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class Menu_MenuCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenuTypes_MenuTypeId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuTypeId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuTypeId",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "MenuCategoryId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuCategoryId",
                table: "Menus",
                column: "MenuCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_MenuCategories_MenuCategoryId",
                table: "Menus",
                column: "MenuCategoryId",
                principalTable: "MenuCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenuCategories_MenuCategoryId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuCategoryId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuCategoryId",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "MenuTypeId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuTypeId",
                table: "Menus",
                column: "MenuTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_MenuTypes_MenuTypeId",
                table: "Menus",
                column: "MenuTypeId",
                principalTable: "MenuTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
