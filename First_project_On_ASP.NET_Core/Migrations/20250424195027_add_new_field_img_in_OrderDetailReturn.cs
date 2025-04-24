using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class add_new_field_img_in_OrderDetailReturn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailReturn_Places_placeId",
                table: "OrderDetailReturn");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetailReturn_placeId",
                table: "OrderDetailReturn");

            migrationBuilder.DropColumn(
                name: "placeId",
                table: "OrderDetailReturn");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "OrderDetailReturn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailReturn_placeReturnID",
                table: "OrderDetailReturn",
                column: "placeReturnID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailReturn_Places_placeReturnID",
                table: "OrderDetailReturn",
                column: "placeReturnID",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailReturn_Places_placeReturnID",
                table: "OrderDetailReturn");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetailReturn_placeReturnID",
                table: "OrderDetailReturn");

            migrationBuilder.DropColumn(
                name: "img",
                table: "OrderDetailReturn");

            migrationBuilder.AddColumn<int>(
                name: "placeId",
                table: "OrderDetailReturn",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailReturn_placeId",
                table: "OrderDetailReturn",
                column: "placeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailReturn_Places_placeId",
                table: "OrderDetailReturn",
                column: "placeId",
                principalTable: "Places",
                principalColumn: "Id");
        }
    }
}
