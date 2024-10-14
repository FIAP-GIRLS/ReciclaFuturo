using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReciclaFuturo.Migrations
{
    /// <inheritdoc />
    public partial class AlterCpfColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "TB_RF_MORADOR",
                type: "NVARCHAR2(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraAgendamento",
                table: "TB_RF_AGENDAMENTO",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cpf",
                table: "TB_RF_MORADOR",
                type: "NUMBER(10)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraAgendamento",
                table: "TB_RF_AGENDAMENTO",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
