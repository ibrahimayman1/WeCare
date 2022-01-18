using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccsess_Layer.Migrations
{
    public partial class ParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentID",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ParentID",
                table: "Customers",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_ParentID",
                table: "Customers",
                column: "ParentID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_ParentID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ParentID",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "ParentID",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
