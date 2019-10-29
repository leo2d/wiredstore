using Microsoft.EntityFrameworkCore.Migrations;

namespace Wired.Migrations
{
    public partial class PromoCodeConfigUP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "wired_promo_code",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "wired_promo_code");
        }
    }
}
