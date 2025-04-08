using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grocery.Data.Migrations
{
    /// <inheritdoc />
    public partial class noPrudectOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductOrders_ProductOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductOrderId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductOrderId",
                table: "Orders",
                newName: "QuantityOrder");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "QuantityOrder",
                table: "Orders",
                newName: "ProductOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductOrderId",
                table: "Orders",
                column: "ProductOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductOrders_ProductOrderId",
                table: "Orders",
                column: "ProductOrderId",
                principalTable: "ProductOrders",
                principalColumn: "Id");
        }
    }
}
