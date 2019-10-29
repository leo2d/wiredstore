using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wired.Migrations
{
    public partial class cartConfigUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wired_customer_wired_cart_Id",
                table: "wired_customer");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "wired_customer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_wired_cart_CustomerId",
                table: "wired_cart",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_wired_cart_wired_customer_CustomerId",
                table: "wired_cart",
                column: "CustomerId",
                principalTable: "wired_customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wired_cart_wired_customer_CustomerId",
                table: "wired_cart");

            migrationBuilder.DropIndex(
                name: "IX_wired_cart_CustomerId",
                table: "wired_cart");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "wired_customer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_wired_customer_wired_cart_Id",
                table: "wired_customer",
                column: "Id",
                principalTable: "wired_cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
