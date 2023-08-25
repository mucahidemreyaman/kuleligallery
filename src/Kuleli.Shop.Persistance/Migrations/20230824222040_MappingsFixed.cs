using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuleli.Shop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class MappingsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CUSTOMER_CITY_CITY_ID",
                table: "CUSTOMERS");

            migrationBuilder.DropColumn(
                name: "DELIVERY_TYPE",
                table: "ORDERS");

            migrationBuilder.DropColumn(
                name: "OrderTime",
                table: "ORDERS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LAST_LOGIN_DATE",
                table: "ACCOUNTS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "CUSTOMER_CITY_CITY_ID",
                table: "CUSTOMERS",
                column: "CITY_ID",
                principalTable: "CITIES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CUSTOMER_CITY_CITY_ID",
                table: "CUSTOMERS");

            migrationBuilder.AddColumn<int>(
                name: "DELIVERY_TYPE",
                table: "ORDERS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<int>(
                name: "OrderTime",
                table: "ORDERS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LAST_LOGIN_DATE",
                table: "ACCOUNTS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "CUSTOMER_CITY_CITY_ID",
                table: "CUSTOMERS",
                column: "CITY_ID",
                principalTable: "CITIES",
                principalColumn: "ID");
        }
    }
}
