using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFinal.Server.Migrations
{
    /// <inheritdoc />
    public partial class AaIdNulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_AreasAtendimento_AaId",
                table: "Logins");

            migrationBuilder.AlterColumn<int>(
                name: "AaId",
                table: "Logins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_AreasAtendimento_AaId",
                table: "Logins",
                column: "AaId",
                principalTable: "AreasAtendimento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_AreasAtendimento_AaId",
                table: "Logins");

            migrationBuilder.AlterColumn<int>(
                name: "AaId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_AreasAtendimento_AaId",
                table: "Logins",
                column: "AaId",
                principalTable: "AreasAtendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
