using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReciclaFuturo.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_RF_ENDERECO",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeEndereco = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    NumeroEndereco = table.Column<int>(type: "NUMBER(10)", maxLength: 6, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(32)", maxLength: 32, nullable: false),
                    Cep = table.Column<int>(type: "NUMBER(10)", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(32)", maxLength: 32, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(32)", maxLength: 32, nullable: false),
                    complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RF_ENDERECO", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "TB_RF_VEICULO",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PlacaVeiculo = table.Column<string>(type: "NVARCHAR2(16)", maxLength: 16, nullable: false),
                    CapacidadeVeiculo = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    NomeMotorista = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RF_VEICULO", x => x.VeiculoId);
                });

            migrationBuilder.CreateTable(
                name: "TB_RF_MORADOR",
                columns: table => new
                {
                    MoradorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    Cpf = table.Column<int>(type: "NUMBER(10)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(32)", maxLength: 32, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(17)", maxLength: 17, nullable: false),
                    ContatoNr = table.Column<string>(type: "NVARCHAR2(16)", maxLength: 16, nullable: true),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RF_MORADOR", x => x.MoradorId);
                    table.ForeignKey(
                        name: "FK_TB_RF_MORADOR_TB_RF_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "TB_RF_ENDERECO",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_RF_ROTA",
                columns: table => new
                {
                    RotaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataHoraRota = table.Column<DateTime>(type: "date", nullable: false),
                    StatusRota = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    AgendamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VeiculoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RF_ROTA", x => x.RotaId);
                    table.ForeignKey(
                        name: "FK_TB_RF_ROTA_TB_RF_VEICULO_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TB_RF_VEICULO",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_RF_AGENDAMENTO",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataHoraAgendamento = table.Column<DateTime>(type: "date", nullable: true),
                    MoradorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RotaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RF_AGENDAMENTO", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_TB_RF_AGENDAMENTO_TB_RF_MORADOR_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "TB_RF_MORADOR",
                        principalColumn: "MoradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RF_AGENDAMENTO_TB_RF_ROTA_RotaId",
                        column: x => x.RotaId,
                        principalTable: "TB_RF_ROTA",
                        principalColumn: "RotaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_RF_RESIDUO",
                columns: table => new
                {
                    ResiduoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ResiduoNome = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    TipoResiduo = table.Column<string>(type: "NVARCHAR2(12)", maxLength: 12, nullable: false),
                    QtdResiduo = table.Column<int>(type: "NUMBER(10)", maxLength: 32, nullable: false),
                    MedidaResiduo = table.Column<string>(type: "NVARCHAR2(17)", maxLength: 17, nullable: false),
                    AgendamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RF_RESIDUO", x => x.ResiduoId);
                    table.ForeignKey(
                        name: "FK_TB_RF_RESIDUO_TB_RF_AGENDAMENTO_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "TB_RF_AGENDAMENTO",
                        principalColumn: "AgendamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_RF_AGENDAMENTO_MoradorId",
                table: "TB_RF_AGENDAMENTO",
                column: "MoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RF_AGENDAMENTO_RotaId",
                table: "TB_RF_AGENDAMENTO",
                column: "RotaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RF_MORADOR_Cpf",
                table: "TB_RF_MORADOR",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_RF_MORADOR_Email",
                table: "TB_RF_MORADOR",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_RF_MORADOR_EnderecoId",
                table: "TB_RF_MORADOR",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RF_RESIDUO_AgendamentoId",
                table: "TB_RF_RESIDUO",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RF_ROTA_VeiculoId",
                table: "TB_RF_ROTA",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RF_VEICULO_PlacaVeiculo",
                table: "TB_RF_VEICULO",
                column: "PlacaVeiculo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_RF_RESIDUO");

            migrationBuilder.DropTable(
                name: "TB_RF_AGENDAMENTO");

            migrationBuilder.DropTable(
                name: "TB_RF_MORADOR");

            migrationBuilder.DropTable(
                name: "TB_RF_ROTA");

            migrationBuilder.DropTable(
                name: "TB_RF_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_RF_VEICULO");
        }
    }
}
