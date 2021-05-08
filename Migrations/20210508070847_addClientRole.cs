using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreVer4.Migrations
{
    public partial class addClientRole : Migration
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
                name: "clients",
                columns: table => new
                {
                    clientid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    clientPassword = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<int>(nullable: false),
                    role = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_books_authorId",
                table: "books",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_genreId",
                table: "books",
                column: "genreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "genres");
        }
    }
}
