using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class change_relation_between_place_and_Order : Migration
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

            migrationBuilder.DropColumn(
                name: "placeTakedId",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Order_placeId",
                table: "Order",
                column: "placeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Places_placeId",
                table: "Order",
                column: "placeId",
                principalTable: "Places",
                principalColumn: "Id");
        }
    }
}
