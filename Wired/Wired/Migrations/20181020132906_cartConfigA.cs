using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wired.Migrations
{
    public partial class cartConfigA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_wired_customer_CustomerId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_wired_cart_item_Cart_CartID",
                table: "wired_cart_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "wired_cart");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "wired_customer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_wired_cart",
                table: "wired_cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_wired_cart_item_wired_cart_CartID",
                table: "wired_cart_item",
                column: "CartID",
                principalTable: "wired_cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wired_customer_wired_cart_Id",
                table: "wired_customer",
                column: "Id",
                principalTable: "wired_cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wired_cart_item_wired_cart_CartID",
                table: "wired_cart_item");

            migrationBuilder.DropForeignKey(
                name: "FK_wired_customer_wired_cart_Id",
                table: "wired_customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wired_cart",
                table: "wired_cart");

            migrationBuilder.RenameTable(
                name: "wired_cart",
                newName: "Cart");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "wired_customer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_wired_customer_CustomerId",
                table: "Cart",
                column: "CustomerId",
                principalTable: "wired_customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wired_cart_item_Cart_CartID",
                table: "wired_cart_item",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
