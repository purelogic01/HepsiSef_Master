using Microsoft.EntityFrameworkCore.Migrations;

namespace HepsiSef.DAL.Migrations
{
    public partial class InitDB_20190516 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "Recipe",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "Recipe");
        }
    }
}
