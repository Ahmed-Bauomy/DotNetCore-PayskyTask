using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploymentSystem.Infrastructure.Migrations
{
    public partial class make_EmployerId_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_AspNetUsers_EmployerId",
                table: "Vacancies");

            migrationBuilder.AlterColumn<string>(
                name: "EmployerId",
                table: "Vacancies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_AspNetUsers_EmployerId",
                table: "Vacancies",
                column: "EmployerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_AspNetUsers_EmployerId",
                table: "Vacancies");

            migrationBuilder.AlterColumn<string>(
                name: "EmployerId",
                table: "Vacancies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_AspNetUsers_EmployerId",
                table: "Vacancies",
                column: "EmployerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
