using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreVer4.Migrations
{
    public partial class buyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adressDelivery",
                table: "buy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adressDelivery",
                table: "buy");
        }
    }
}
