using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class MenuItemNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnlyNote",
                table: "MenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "MenuItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnlyNote",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "MenuItems");
        }
    }
}
