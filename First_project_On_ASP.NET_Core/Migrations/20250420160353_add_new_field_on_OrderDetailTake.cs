using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class add_new_field_on_OrderDetailTake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "OrderDetailUp");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "OrderDetailUp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailUp_userId",
                table: "OrderDetailUp",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailUp_User_userId",
                table: "OrderDetailUp",
                column: "userId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailUp_User_userId",
                table: "OrderDetailUp");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetailUp_userId",
                table: "OrderDetailUp");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "OrderDetailUp");

            migrationBuilder.AddColumn<long>(
                name: "price",
                table: "OrderDetailUp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
