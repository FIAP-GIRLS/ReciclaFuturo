﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using ReciclaFuturo.Data.Contexts;

#nullable disable

namespace ReciclaFuturo.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReciclaFuturo.Models.AgendamentoModel", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoId"));

                    b.Property<DateTime?>("DataHoraAgendamento")
                        .HasColumnType("date");

                    b.Property<int>("MoradorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("RotaId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("MoradorId");

                    b.HasIndex("RotaId");

                    b.ToTable("TB_RF_AGENDAMENTO", (string)null);
                });

            modelBuilder.Entity("ReciclaFuturo.Models.EnderecoModel", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoId"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("NVARCHAR2(32)");

                    b.Property<int?>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("NVARCHAR2(32)");

                    b.Property<string>("Complemento")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("NVARCHAR2(32)");

                    b.Property<string>("NomeEndereco")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("NVARCHAR2(64)");

                    b.Property<int?>("NumeroEndereco")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EnderecoId");

                    b.ToTable("TB_RF_ENDERECO", (string)null);
                });

            modelBuilder.Entity("ReciclaFuturo.Models.MoradorModel", b =>
                {
                    b.Property<int>("MoradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MoradorId"));

                    b.Property<string>("ContatoNr")
                        .HasMaxLength(16)
                        .HasColumnType("NVARCHAR2(16)");

                    b.Property<int>("Cpf")
                        .HasMaxLength(12)
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("NVARCHAR2(32)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("NVARCHAR2(64)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("NVARCHAR2(17)");

                    b.HasKey("MoradorId");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("EnderecoId");

                    b.ToTable("TB_RF_MORADOR", (string)null);
                });

            modelBuilder.Entity("ReciclaFuturo.Models.ResiduoModel", b =>
                {
                    b.Property<int>("ResiduoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResiduoId"));

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("MedidaResiduo")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("NVARCHAR2(17)");

                    b.Property<int>("QtdResiduo")
                        .HasMaxLength(32)
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("ResiduoNome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("NVARCHAR2(64)");

                    b.Property<string>("TipoResiduo")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("NVARCHAR2(12)");

                    b.HasKey("ResiduoId");

                    b.HasIndex("AgendamentoId");

                    b.ToTable("TB_RF_RESIDUO", (string)null);
                });

            modelBuilder.Entity("ReciclaFuturo.Models.RotaModel", b =>
                {
                    b.Property<int>("RotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RotaId"));

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("DataHoraRota")
                        .HasColumnType("date");

                    b.Property<string>("StatusRota")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("NVARCHAR2(64)");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("RotaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TB_RF_ROTA", (string)null);
                });

            modelBuilder.Entity("ReciclaFuturo.Models.VeiculoModel", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VeiculoId"));

                    b.Property<float>("CapacidadeVeiculo")
                        .HasColumnType("BINARY_FLOAT");

                    b.Property<string>("NomeMotorista")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("NVARCHAR2(64)");

                    b.Property<string>("PlacaVeiculo")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("NVARCHAR2(16)");

                    b.HasKey("VeiculoId");

                    b.HasIndex("PlacaVeiculo")
                        .IsUnique();

                    b.ToTable("TB_RF_VEICULO", (string)null);
                });

            modelBuilder.Entity("ReciclaFuturo.Models.AgendamentoModel", b =>
                {
                    b.HasOne("ReciclaFuturo.Models.MoradorModel", "Morador")
                        .WithMany("Agendamentos")
                        .HasForeignKey("MoradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReciclaFuturo.Models.RotaModel", "Rota")
                        .WithMany("Agendamentos")
                        .HasForeignKey("RotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Morador");

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("ReciclaFuturo.Models.MoradorModel", b =>
                {
                    b.HasOne("ReciclaFuturo.Models.EnderecoModel", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ReciclaFuturo.Models.ResiduoModel", b =>
                {
                    b.HasOne("ReciclaFuturo.Models.AgendamentoModel", "Agendamento")
                        .WithMany("Residuos")
                        .HasForeignKey("AgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agendamento");
                });

            modelBuilder.Entity("ReciclaFuturo.Models.RotaModel", b =>
                {
                    b.HasOne("ReciclaFuturo.Models.VeiculoModel", "Veiculo")
                        .WithMany("Rotas")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("ReciclaFuturo.Models.AgendamentoModel", b =>
                {
                    b.Navigation("Residuos");
                });

            modelBuilder.Entity("ReciclaFuturo.Models.MoradorModel", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("ReciclaFuturo.Models.RotaModel", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("ReciclaFuturo.Models.VeiculoModel", b =>
                {
                    b.Navigation("Rotas");
                });
#pragma warning restore 612, 618
        }
    }
}
