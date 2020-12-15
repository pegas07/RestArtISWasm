using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class SeedMenuType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Denní" });

            migrationBuilder.InsertData(
                table: "MenuTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Týdenní" });

            migrationBuilder.InsertData(
                table: "MenuTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Stálé" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
