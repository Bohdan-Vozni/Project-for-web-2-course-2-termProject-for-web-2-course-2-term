using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class change_review_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_OrderDetailReturn_orderDetailReturnId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "orderDetailReturnId",
                table: "Reviews",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_orderDetailReturnId",
                table: "Reviews",
                newName: "IX_Reviews_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_User_userId",
                table: "Reviews",
                column: "userId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_User_userId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Reviews",
                newName: "orderDetailReturnId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_userId",
                table: "Reviews",
                newName: "IX_Reviews_orderDetailReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_OrderDetailReturn_orderDetailReturnId",
                table: "Reviews",
                column: "orderDetailReturnId",
                principalTable: "OrderDetailReturn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
