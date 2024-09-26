using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerDesarrollo.Migrations
{
    /// <inheritdoc />
    public partial class vendedorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Empresas_EmpresaCodigo",
                table: "Personas");

            migrationBuilder.AddColumn<string>(
                name: "Carne",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Empresas_EmpresaCodigo",
                table: "Personas",
                column: "EmpresaCodigo",
                principalTable: "Empresas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Empresas_EmpresaCodigo",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Carne",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Personas");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Empresas_EmpresaCodigo",
                table: "Personas",
                column: "EmpresaCodigo",
                principalTable: "Empresas",
                principalColumn: "Codigo");
        }
    }
}
