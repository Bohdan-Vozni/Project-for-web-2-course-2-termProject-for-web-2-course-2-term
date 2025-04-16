using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class Add_Place_OrderDatailReturn_Reviews_and_Logic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_User_Userid",
                table: "ShopCartItem");

            migrationBuilder.DropColumn(
                name: "ShopCartId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "ShopCartItem",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_Userid",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShopCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "placeId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "placeTakedId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "placeID",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderDetailId = table.Column<int>(type: "int", nullable: false),
                    placeReturnID = table.Column<int>(type: "int", nullable: false),
                    placeId = table.Column<int>(type: "int", nullable: true),
                    dataTime_return = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isReturning = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailReturn_OrderDetailUp_orderDetailId",
                        column: x => x.orderDetailId,
                        principalTable: "OrderDetailUp",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailReturn_Places_placeId",
                        column: x => x.placeId,
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderDetailReturnId = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_OrderDetailReturn_orderDetailReturnId",
                        column: x => x.orderDetailReturnId,
                        principalTable: "OrderDetailReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_placeId",
                table: "Order",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_placeID",
                table: "Car",
                column: "placeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailReturn_orderDetailId",
                table: "OrderDetailReturn",
                column: "orderDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailReturn_placeId",
                table: "OrderDetailReturn",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_orderDetailReturnId",
                table: "Reviews",
                column: "orderDetailReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Places_placeID",
                table: "Car",
                column: "placeID",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Places_placeId",
                table: "Order",
                column: "placeId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_User_UserId",
                table: "ShopCartItem",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Places_placeID",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Places_placeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_User_UserId",
                table: "ShopCartItem");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "OrderDetailReturn");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Order_placeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Car_placeID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "placeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "placeTakedId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "placeID",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShopCartItem",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_UserId",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_Userid");

            migrationBuilder.AddColumn<string>(
                name: "ShopCartId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "ShopCartItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_User_Userid",
                table: "ShopCartItem",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
