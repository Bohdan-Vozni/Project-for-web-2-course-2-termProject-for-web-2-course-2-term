using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class Fix_ShopCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Car_carid",
                table: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "carid",
                table: "ShopCartItem",
                newName: "CarID");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_carid",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_CarID");

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "ShopCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Car_CarID",
                table: "ShopCartItem",
                column: "CarID",
                principalTable: "Car",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Car_CarID",
                table: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "CarID",
                table: "ShopCartItem",
                newName: "carid");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_CarID",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_carid");

            migrationBuilder.AlterColumn<int>(
                name: "carid",
                table: "ShopCartItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Car_carid",
                table: "ShopCartItem",
                column: "carid",
                principalTable: "Car",
                principalColumn: "id");
        }
    }
}
