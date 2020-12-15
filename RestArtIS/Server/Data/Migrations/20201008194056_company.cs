using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Data.Migrations
{
    public partial class company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "BusinessPartners",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MailingAddressId",
                table: "BusinessPartners",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MailingAddressSameAsBillingAddress",
                table: "BusinessPartners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPartners_BillingAddressId",
                table: "BusinessPartners",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPartners_MailingAddressId",
                table: "BusinessPartners",
                column: "MailingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPartners_Addresses_BillingAddressId",
                table: "BusinessPartners",
                column: "BillingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPartners_Addresses_MailingAddressId",
                table: "BusinessPartners",
                column: "MailingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPartners_Addresses_BillingAddressId",
                table: "BusinessPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPartners_Addresses_MailingAddressId",
                table: "BusinessPartners");

            migrationBuilder.DropIndex(
                name: "IX_BusinessPartners_BillingAddressId",
                table: "BusinessPartners");

            migrationBuilder.DropIndex(
                name: "IX_BusinessPartners_MailingAddressId",
                table: "BusinessPartners");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "BusinessPartners");

            migrationBuilder.DropColumn(
                name: "MailingAddressId",
                table: "BusinessPartners");

            migrationBuilder.DropColumn(
                name: "MailingAddressSameAsBillingAddress",
                table: "BusinessPartners");
        }
    }
}
