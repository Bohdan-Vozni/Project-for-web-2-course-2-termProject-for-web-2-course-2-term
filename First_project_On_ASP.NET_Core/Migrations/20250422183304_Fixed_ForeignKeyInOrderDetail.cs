using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_ForeignKeyInOrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Places_placeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_placeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "placeId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "placeId",
                table: "OrderDetailUp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailUp_placeId",
                table: "OrderDetailUp",
                column: "placeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailUp_Places_placeId",
                table: "OrderDetailUp",
                column: "placeId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailUp_Places_placeId",
                table: "OrderDetailUp");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetailUp_placeId",
                table: "OrderDetailUp");

            migrationBuilder.DropColumn(
                name: "placeId",
                table: "OrderDetailUp");

            migrationBuilder.AddColumn<int>(
                name: "placeId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_placeId",
                table: "Order",
                column: "placeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Places_placeId",
                table: "Order",
                column: "placeId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
