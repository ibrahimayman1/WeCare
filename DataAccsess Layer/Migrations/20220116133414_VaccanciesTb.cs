using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccsess_Layer.Migrations
{
    public partial class VaccanciesTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccancies",
                columns: table => new
                {
                    VaccineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineTittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccineMonths = table.Column<int>(type: "int", nullable: false),
                    VaccineTypeID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccancies", x => x.VaccineID);
                    table.ForeignKey(
                        name: "FK_Vaccancies_VaccineTypes_VaccineTypeID",
                        column: x => x.VaccineTypeID,
                        principalTable: "VaccineTypes",
                        principalColumn: "VaccineTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccancies_VaccineTypeID",
                table: "Vaccancies",
                column: "VaccineTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccancies");
        }
    }
}
