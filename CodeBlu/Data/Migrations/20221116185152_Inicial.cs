using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBlu.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    ZonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.ZonaId);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    PersonalMedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ZonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.PersonalMedicoId);
                    table.ForeignKey(
                        name: "FK_Personal_Zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zonas",
                        principalColumn: "ZonaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactoEmergencia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Asma = table.Column<bool>(type: "bit", nullable: false),
                    TuvoVaricela = table.Column<bool>(type: "bit", nullable: false),
                    TipoSangre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ObraSocial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MedicoCabecera = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiagnosticoIngreso = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Alergia = table.Column<bool>(type: "bit", nullable: false),
                    DetalleAlergia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PatologiaBase = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TomaMedicacion = table.Column<bool>(type: "bit", nullable: false),
                    DetalleMedicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZonaId = table.Column<int>(type: "int", nullable: false),
                    PersonaMedicoId = table.Column<int>(type: "int", nullable: false),
                    PersonalMedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Pacientes_Personal_PersonalMedicoId",
                        column: x => x.PersonalMedicoId,
                        principalTable: "Personal",
                        principalColumn: "PersonalMedicoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pacientes_Zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zonas",
                        principalColumn: "ZonaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Llamados",
                columns: table => new
                {
                    LlamadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLlamado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrigenLlamado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Atendido = table.Column<bool>(type: "bit", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraAtendido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalMedicoId = table.Column<int>(type: "int", nullable: false),
                    ZonaId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamados", x => x.LlamadoId);
                    table.ForeignKey(
                        name: "FK_Llamados_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Llamados_Personal_PersonalMedicoId",
                        column: x => x.PersonalMedicoId,
                        principalTable: "Personal",
                        principalColumn: "PersonalMedicoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Llamados_Zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zonas",
                        principalColumn: "ZonaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Llamados_PacienteId",
                table: "Llamados",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Llamados_PersonalMedicoId",
                table: "Llamados",
                column: "PersonalMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Llamados_ZonaId",
                table: "Llamados",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DNI",
                table: "Pacientes",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PersonalMedicoId",
                table: "Pacientes",
                column: "PersonalMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ZonaId",
                table: "Pacientes",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_DNI",
                table: "Personal",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personal_ZonaId",
                table: "Personal",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DNI",
                table: "Usuarios",
                column: "DNI");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Usuario",
                table: "Usuarios",
                column: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Llamados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Zonas");
        }
    }
}
