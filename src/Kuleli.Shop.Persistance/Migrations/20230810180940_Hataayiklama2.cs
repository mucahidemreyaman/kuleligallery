using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuleli.Shop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Hataayiklama2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ORDER_CUSTOMER_CUSTOMER_ID",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "COOMENT_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_COMMENTS");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PRODUCTS_TempId",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "PRODUCTS");

            migrationBuilder.AddForeignKey(
                name: "ORDERS_CUSTOMER_CUSTOMER_ID",
                table: "ORDERS",
                column: "CUTOMER_ID",
                principalTable: "CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "COOMENT_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_COMMENTS",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ORDERS_CUSTOMER_CUSTOMER_ID",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "COOMENT_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_COMMENTS");

            migrationBuilder.AddColumn<string>(
                name: "TempId",
                table: "PRODUCTS",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PRODUCTS_TempId",
                table: "PRODUCTS",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "ORDER_CUSTOMER_CUSTOMER_ID",
                table: "ORDERS",
                column: "CUTOMER_ID",
                principalTable: "CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "COOMENT_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_COMMENTS",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
