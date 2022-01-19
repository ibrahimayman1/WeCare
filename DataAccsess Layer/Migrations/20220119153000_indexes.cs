using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccsess_Layer.Migrations
{
    public partial class indexes : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNumber2",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNote",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "kidsCustomerID",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccineTypes_VaccineTypeTittle",
                table: "VaccineTypes",
                column: "VaccineTypeTittle");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccancies_VaccineTittle",
                table: "Vaccancies",
                column: "VaccineTittle");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_InterestsTittle",
                table: "Interests",
                column: "InterestsTittle");

            migrationBuilder.CreateIndex(
                name: "IX_DrugsGroups_GroupTittle",
                table: "DrugsGroups",
                column: "GroupTittle");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_DrugTitle",
                table: "Drugs",
                column: "DrugTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Distructs_DistrictTitle",
                table: "Distructs",
                column: "DistrictTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerName",
                table: "Customers",
                column: "CustomerName");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_kidsCustomerID",
                table: "Customers",
                column: "kidsCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CityTittle",
                table: "City",
                column: "CityTittle");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_kidsCustomerID",
                table: "Customers",
                column: "kidsCustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_kidsCustomerID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_VaccineTypes_VaccineTypeTittle",
                table: "VaccineTypes");

            migrationBuilder.DropIndex(
                name: "IX_Vaccancies_VaccineTittle",
                table: "Vaccancies");

            migrationBuilder.DropIndex(
                name: "IX_Interests_InterestsTittle",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_DrugsGroups_GroupTittle",
                table: "DrugsGroups");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_DrugTitle",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Distructs_DistrictTitle",
                table: "Distructs");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerName",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_kidsCustomerID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_City_CityTittle",
                table: "City");

            migrationBuilder.DropColumn(
                name: "kidsCustomerID",
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

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNumber2",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNote",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
