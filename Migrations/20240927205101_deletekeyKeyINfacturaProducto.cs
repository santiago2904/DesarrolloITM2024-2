using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerDesarrollo.Migrations
{
    /// <inheritdoc />
    public partial class deletekeyKeyINfacturaProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturaProductos",
                table: "FacturaProductos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturaProductos",
                table: "FacturaProductos",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaProductos_FacturaId",
                table: "FacturaProductos",
                column: "FacturaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturaProductos",
                table: "FacturaProductos");

            migrationBuilder.DropIndex(
                name: "IX_FacturaProductos_FacturaId",
                table: "FacturaProductos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturaProductos",
                table: "FacturaProductos",
                columns: new[] { "FacturaId", "ProductoId" });
        }
    }
}
