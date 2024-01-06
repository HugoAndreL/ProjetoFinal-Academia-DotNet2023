using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFinal.Server.Migrations
{
    /// <inheritdoc />
    public partial class LoginAreaAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AaId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_AaId",
                table: "Logins",
                column: "AaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_AreasAtendimento_AaId",
                table: "Logins",
                column: "AaId",
                principalTable: "AreasAtendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_AreasAtendimento_AaId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_AaId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "AaId",
                table: "Logins");
        }
    }
}
