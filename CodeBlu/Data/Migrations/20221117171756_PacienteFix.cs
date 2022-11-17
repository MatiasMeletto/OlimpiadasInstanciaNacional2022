using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBlu.Data.Migrations
{
    public partial class PacienteFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonaMedicoId",
                table: "Pacientes");

            migrationBuilder.AddColumn<string>(
                name: "NAfiliado",
                table: "Pacientes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NAfiliado",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "PersonaMedicoId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
