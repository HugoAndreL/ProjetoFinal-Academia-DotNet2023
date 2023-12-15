using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFinal.Server.Migrations
{
    /// <inheritdoc />
    public partial class HistoricoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoUsuarios");
        }
    }
}
