using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuleli.Shop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CityIdIsNotRequiredFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CUSTOMER_CITY_CITY_ID",
                table: "CUSTOMERS");

            migrationBuilder.AddForeignKey(
                name: "CUSTOMER_CITY_CITY_ID",
                table: "CUSTOMERS",
                column: "CITY_ID",
                principalTable: "CITIES",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CUSTOMER_CITY_CITY_ID",
                table: "CUSTOMERS");

            migrationBuilder.AddForeignKey(
                name: "CUSTOMER_CITY_CITY_ID",
                table: "CUSTOMERS",
                column: "CITY_ID",
                principalTable: "CITIES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
