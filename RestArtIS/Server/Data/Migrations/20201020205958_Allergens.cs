using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class Allergens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 2, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    NameAddition = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Code", "Name", "NameAddition" },
                values: new object[,]
                {
                    { 1, "1", "Obiloviny obsahující lepek", "pšenice, žito, ječmen, oves, špalda, kamut nebo jejich odrůdy a výrobky z nich" },
                    { 2, "2", "Korýši", "a výrobky z nich" },
                    { 3, "3", "Vejce", "a výrobky z nich" },
                    { 4, "4", "Ryby", "a výrobky z nich" },
                    { 5, "5", "Jádra podzemnice olejné (arašídy)", "a výrobky z nich" },
                    { 6, "6", "Sójové boby (sója)", "a výrobky z nich" },
                    { 7, "7", "Mléko", "a výrobky z něj" },
                    { 8, "8", "Skořápkové plody", "Mandle, lískové ořechy, vlašské ořechy, kešu ořechy, pekanové ořechy, para ořechy, pistácie, makadamie a výrobky z nich" },
                    { 9, "9", "Celer", "a výrobky z něj" },
                    { 10, "10", "Hořčice", "a výrobky z ní" },
                    { 11, "11", "Sezamová semena (sezam)", "a výrobky z nich" },
                    { 12, "12", "Oxid siřičitý a siřičitany", "v koncentracích vyšších než 10 mg, ml/kg, l, vyjádřeno SO2" },
                    { 13, "13", "Vlčí bob (lupina)", "a výrobky z něj" },
                    { 14, "14", "Měkkýši", "a výrobky z nich" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");
        }
    }
}
