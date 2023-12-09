using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFinal.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guiches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guiches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Triagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senhas",
                columns: table => new
                {
                    Senha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoricoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senhas", x => x.Senha);
                    table.ForeignKey(
                        name: "FK_Senhas_Historico_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "Historico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SenhasConsultorios",
                columns: table => new
                {
                    SenhaId = table.Column<int>(type: "int", nullable: false),
                    ConsultorioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenhasConsultorios", x => new { x.SenhaId, x.ConsultorioId });
                    table.ForeignKey(
                        name: "FK_SenhasConsultorios_Consultorios_ConsultorioId",
                        column: x => x.ConsultorioId,
                        principalTable: "Consultorios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SenhasConsultorios_Senhas_SenhaId",
                        column: x => x.SenhaId,
                        principalTable: "Senhas",
                        principalColumn: "Senha");
                });

            migrationBuilder.CreateTable(
                name: "SenhasGuiches",
                columns: table => new
                {
                    SenhaId = table.Column<int>(type: "int", nullable: false),
                    GuicheId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenhasGuiches", x => new { x.SenhaId, x.GuicheId });
                    table.ForeignKey(
                        name: "FK_SenhasGuiches_Guiches_GuicheId",
                        column: x => x.GuicheId,
                        principalTable: "Guiches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SenhasGuiches_Senhas_SenhaId",
                        column: x => x.SenhaId,
                        principalTable: "Senhas",
                        principalColumn: "Senha");
                });

            migrationBuilder.CreateTable(
                name: "SenhasTriagens",
                columns: table => new
                {
                    SenhaId = table.Column<int>(type: "int", nullable: false),
                    TriagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenhasTriagens", x => new { x.SenhaId, x.TriagemId });
                    table.ForeignKey(
                        name: "FK_SenhasTriagens_Senhas_SenhaId",
                        column: x => x.SenhaId,
                        principalTable: "Senhas",
                        principalColumn: "Senha");
                    table.ForeignKey(
                        name: "FK_SenhasTriagens_Triagens_TriagemId",
                        column: x => x.TriagemId,
                        principalTable: "Triagens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Senhas_HistoricoId",
                table: "Senhas",
                column: "HistoricoId");

            migrationBuilder.CreateIndex(
                name: "IX_SenhasConsultorios_ConsultorioId",
                table: "SenhasConsultorios",
                column: "ConsultorioId");

            migrationBuilder.CreateIndex(
                name: "IX_SenhasGuiches_GuicheId",
                table: "SenhasGuiches",
                column: "GuicheId");

            migrationBuilder.CreateIndex(
                name: "IX_SenhasTriagens_TriagemId",
                table: "SenhasTriagens",
                column: "TriagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "SenhasConsultorios");

            migrationBuilder.DropTable(
                name: "SenhasGuiches");

            migrationBuilder.DropTable(
                name: "SenhasTriagens");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Guiches");

            migrationBuilder.DropTable(
                name: "Senhas");

            migrationBuilder.DropTable(
                name: "Triagens");

            migrationBuilder.DropTable(
                name: "Historico");
        }
    }
}
