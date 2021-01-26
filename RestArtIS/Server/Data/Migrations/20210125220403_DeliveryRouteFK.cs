using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class DeliveryRouteFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryRouteId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryRouteId",
                table: "BusinessPartners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryRouteId",
                table: "Orders",
                column: "DeliveryRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPartners_DeliveryRouteId",
                table: "BusinessPartners",
                column: "DeliveryRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPartners_DeliveryRoutes_DeliveryRouteId",
                table: "BusinessPartners",
                column: "DeliveryRouteId",
                principalTable: "DeliveryRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryRoutes_DeliveryRouteId",
                table: "Orders",
                column: "DeliveryRouteId",
                principalTable: "DeliveryRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPartners_DeliveryRoutes_DeliveryRouteId",
                table: "BusinessPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryRoutes_DeliveryRouteId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryRouteId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_BusinessPartners_DeliveryRouteId",
                table: "BusinessPartners");

            migrationBuilder.DropColumn(
                name: "DeliveryRouteId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryRouteId",
                table: "BusinessPartners");
        }
    }
}
