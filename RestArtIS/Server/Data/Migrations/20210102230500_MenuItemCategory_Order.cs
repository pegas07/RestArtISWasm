using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class MenuItemCategory_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryOrder",
                table: "MenuItemCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryOrder",
                table: "MenuItemCategories");
        }
    }
}
