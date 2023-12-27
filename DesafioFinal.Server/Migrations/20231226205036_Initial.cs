using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFinal.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoSenhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Prioridade = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoSenhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    DataRelatorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempoEspera = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    TaxaUtilizacaoGuiche = table.Column<int>(type: "int", nullable: false),
                    TaxaUtilizacaoTriagem = table.Column<int>(type: "int", nullable: false),
                    TaxaUtilizacaoConsultorio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Prioridade = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAreasAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAreasAtendimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    CargoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AreasAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    TipoAreaAtendimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreasAtendimento_TiposAreasAtendimento_TipoAreaAtendimentoId",
                        column: x => x.TipoAreaAtendimentoId,
                        principalTable: "TiposAreasAtendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreasAtendimento_TipoAreaAtendimentoId",
                table: "AreasAtendimento",
                column: "TipoAreaAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoId",
                table: "Usuarios",
                column: "CargoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreasAtendimento");

            migrationBuilder.DropTable(
                name: "HistoricoCargos");

            migrationBuilder.DropTable(
                name: "HistoricoSenhas");

            migrationBuilder.DropTable(
                name: "HistoricoUsuarios");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "Senhas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposAreasAtendimento");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
