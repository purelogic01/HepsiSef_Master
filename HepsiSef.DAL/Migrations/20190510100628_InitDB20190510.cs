using Microsoft.EntityFrameworkCore.Migrations;

namespace HepsiSef.DAL.Migrations
{
    public partial class InitDB20190510 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Contact");

            migrationBuilder.AddColumn<decimal>(
                name: "AvarageRate",
                table: "Recipe",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvarageRate",
                table: "Recipe");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Contact",
                nullable: true);
        }
    }
}
