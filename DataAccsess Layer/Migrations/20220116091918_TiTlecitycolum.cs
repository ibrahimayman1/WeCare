using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccsess_Layer.Migrations
{
    public partial class TiTlecitycolum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityTittle",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityTittle",
                table: "City");
        }
    }
}
