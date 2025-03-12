using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Car_carid",
                table: "ShopCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItems",
                table: "ShopCartItems");

            migrationBuilder.RenameTable(
                name: "ShopCartItems",
                newName: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "ShopCarId",
                table: "ShopCartItem",
                newName: "ShopCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItems_carid",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_carid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Car_carid",
                table: "ShopCartItem",
                column: "carid",
                principalTable: "Car",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Car_carid",
                table: "ShopCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem");

            migrationBuilder.RenameTable(
                name: "ShopCartItem",
                newName: "ShopCartItems");

            migrationBuilder.RenameColumn(
                name: "ShopCartId",
                table: "ShopCartItems",
                newName: "ShopCarId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_carid",
                table: "ShopCartItems",
                newName: "IX_ShopCartItems_carid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItems",
                table: "ShopCartItems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Car_carid",
                table: "ShopCartItems",
                column: "carid",
                principalTable: "Car",
                principalColumn: "id");
        }
    }
}
