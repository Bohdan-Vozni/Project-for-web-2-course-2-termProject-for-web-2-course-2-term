using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class change_Order_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
