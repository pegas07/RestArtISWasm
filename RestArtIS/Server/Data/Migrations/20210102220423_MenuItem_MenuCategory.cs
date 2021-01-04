using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class MenuItem_MenuCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "MenuItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MenuItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MenuItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MenuItems",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MenuCategoryId",
                table: "MenuItemCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemCategories_MenuCategoryId",
                table: "MenuItemCategories",
                column: "MenuCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCategories_MenuCategories_MenuCategoryId",
                table: "MenuItemCategories",
                column: "MenuCategoryId",
                principalTable: "MenuCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCategories_MenuCategories_MenuCategoryId",
                table: "MenuItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemCategories_MenuCategoryId",
                table: "MenuItemCategories");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "MenuCategoryId",
                table: "MenuItemCategories");
        }
    }
}
