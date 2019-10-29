using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wired.Migrations
{
    public partial class initialA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wired_admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Email = table.Column<string>(fixedLength: true, maxLength: 100, nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wired_admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wired_customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Email = table.Column<string>(fixedLength: true, maxLength: 100, nullable: false),
                    Password = table.Column<string>(fixedLength: true, maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(fixedLength: true, maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wired_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wired_genre_game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wired_genre_game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_wired_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "wired_customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wired_game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Producer = table.Column<string>(maxLength: 80, nullable: false),
                    ReleaseYear = table.Column<string>(fixedLength: true, maxLength: 4, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wired_game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wired_game_wired_genre_game_GenreId",
                        column: x => x.GenreId,
                        principalTable: "wired_genre_game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wired_cart_item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false),
                    CartID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wired_cart_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wired_cart_item_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wired_cart_item_wired_game_GameID",
                        column: x => x.GameID,
                        principalTable: "wired_game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wired_images_game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImagePath = table.Column<string>(maxLength: 255, nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wired_images_game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wired_images_game_wired_game_GameId",
                        column: x => x.GameId,
                        principalTable: "wired_game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wired_keys_game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    Key = table.Column<string>(maxLength: 255, nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wired_keys_game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wired_keys_game_wired_game_GameId",
                        column: x => x.GameId,
                        principalTable: "wired_game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_wired_cart_item_CartID",
                table: "wired_cart_item",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_wired_cart_item_GameID",
                table: "wired_cart_item",
                column: "GameID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_wired_game_GenreId",
                table: "wired_game",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_wired_images_game_GameId",
                table: "wired_images_game",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_wired_keys_game_GameId",
                table: "wired_keys_game",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wired_admin");

            migrationBuilder.DropTable(
                name: "wired_cart_item");

            migrationBuilder.DropTable(
                name: "wired_images_game");

            migrationBuilder.DropTable(
                name: "wired_keys_game");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "wired_game");

            migrationBuilder.DropTable(
                name: "wired_customer");

            migrationBuilder.DropTable(
                name: "wired_genre_game");
        }
    }
}
