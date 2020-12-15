using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class VatHistoryFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VatHistories_Vats_VatId",
                table: "VatHistories");

            migrationBuilder.AlterColumn<int>(
                name: "VatId",
                table: "VatHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VatHistories_Vats_VatId",
                table: "VatHistories",
                column: "VatId",
                principalTable: "Vats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VatHistories_Vats_VatId",
                table: "VatHistories");

            migrationBuilder.AlterColumn<int>(
                name: "VatId",
                table: "VatHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VatHistories_Vats_VatId",
                table: "VatHistories",
                column: "VatId",
                principalTable: "Vats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
