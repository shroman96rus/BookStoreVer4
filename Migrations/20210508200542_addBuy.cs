using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreVer4.Migrations
{
    public partial class addBuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "clients");

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "clients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "clientRole",
                table: "clients",
                nullable: true);

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
                name: "buys",
                columns: table => new
                {
                    buyid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bookId = table.Column<int>(nullable: false),
                    clientid = table.Column<int>(nullable: false),
                    cityid = table.Column<int>(nullable: false),
                    buyDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buys", x => x.buyid);
                    table.ForeignKey(
                        name: "FK_buys_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buys_cities_cityid",
                        column: x => x.cityid,
                        principalTable: "cities",
                        principalColumn: "cityid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buys_clients_clientid",
                        column: x => x.clientid,
                        principalTable: "clients",
                        principalColumn: "clientid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buys_bookId",
                table: "buys",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_buys_cityid",
                table: "buys",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_buys_clientid",
                table: "buys",
                column: "clientid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buys");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropColumn(
                name: "clientRole",
                table: "clients");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNumber",
                table: "clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "clients",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
