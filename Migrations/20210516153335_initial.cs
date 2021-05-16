using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreVer4.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    authorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nameAuthor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.authorId);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cityid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cityName = table.Column<string>(nullable: true),
                    deliveryTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.cityid);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    clientid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    clientPassword = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    clientRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.clientid);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    genreId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nameGenre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.genreId);
                });

            migrationBuilder.CreateTable(
                name: "steps",
                columns: table => new
                {
                    stepid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nameStep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_steps", x => x.stepid);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    bookId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    authorId = table.Column<int>(nullable: false),
                    genreId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    bookDescription = table.Column<string>(nullable: true),
                    imagePath = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    amout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_books_authors_authorId",
                        column: x => x.authorId,
                        principalTable: "authors",
                        principalColumn: "authorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_genres_genreId",
                        column: x => x.genreId,
                        principalTable: "genres",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "buy",
                columns: table => new
                {
                    buyid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bookId = table.Column<int>(nullable: false),
                    clientid = table.Column<int>(nullable: false),
                    cityid = table.Column<int>(nullable: false),
                    stepid = table.Column<int>(nullable: false),
                    buyDescription = table.Column<string>(nullable: true),
                    amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buy", x => x.buyid);
                    table.ForeignKey(
                        name: "FK_buy_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buy_cities_cityid",
                        column: x => x.cityid,
                        principalTable: "cities",
                        principalColumn: "cityid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buy_clients_clientid",
                        column: x => x.clientid,
                        principalTable: "clients",
                        principalColumn: "clientid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buy_steps_stepid",
                        column: x => x.stepid,
                        principalTable: "steps",
                        principalColumn: "stepid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_authorId",
                table: "books",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_genreId",
                table: "books",
                column: "genreId");

            migrationBuilder.CreateIndex(
                name: "IX_buy_bookId",
                table: "buy",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_buy_cityid",
                table: "buy",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_buy_clientid",
                table: "buy",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_buy_stepid",
                table: "buy",
                column: "stepid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buy");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "steps");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "genres");
        }
    }
}
