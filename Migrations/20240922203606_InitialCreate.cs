using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerDesarrollo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Credito = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmpresaCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Personas_Empresas_EmpresaCodigo",
                        column: x => x.EmpresaCodigo,
                        principalTable: "Empresas",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EmpresaCodigo",
                table: "Personas",
                column: "EmpresaCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
