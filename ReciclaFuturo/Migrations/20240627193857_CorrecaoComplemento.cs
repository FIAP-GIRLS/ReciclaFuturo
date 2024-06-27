using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReciclaFuturo.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoComplemento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "complemento",
                table: "TB_RF_ENDERECO",
                newName: "Complemento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "TB_RF_ENDERECO",
                newName: "complemento");
        }
    }
}
