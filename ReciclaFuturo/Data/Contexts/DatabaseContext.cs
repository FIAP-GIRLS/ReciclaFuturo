using Microsoft.EntityFrameworkCore;
using ReciclaFuturo.Models;

namespace ReciclaFuturo.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MoradorModel> Morador { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<AgendamentoModel> Agendamento { get; set; }
        public DbSet<ResiduoModel> Residuo { get; set; }
        public DbSet<VeiculoModel> Veiculo { get; set; }
        public DbSet<RotaModel> Rota { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoradorModel>(entity =>
            {
                entity.ToTable("TB_RF_MORADOR");
                entity.HasKey(e => e.MoradorId);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(64);
                entity.Property(e => e.Cpf).IsRequired().HasMaxLength(12);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(32);
                entity.Property(e => e.Senha).IsRequired().HasMaxLength(17);
                entity.Property(e => e.ContatoNr).HasMaxLength(16);
                entity.HasIndex(e => e.Cpf).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasOne(e => e.Endereco)
                      .WithMany()
                      .HasForeignKey(e => e.EnderecoId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Agendamentos)
                      .WithOne(a => a.Morador)
                      .HasForeignKey(a => a.MoradorId);
            });

            modelBuilder.Entity<EnderecoModel>(entity =>
            {
                entity.ToTable("TB_RF_ENDERECO");
                entity.HasKey(e => e.EnderecoId);
                entity.Property(e => e.NomeEndereco).IsRequired().HasMaxLength(64);
                entity.Property(e => e.NumeroEndereco).IsRequired().HasMaxLength(6);
                entity.Property(e => e.Bairro).IsRequired().HasMaxLength(32);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(32);
                entity.Property(e => e.Cidade).IsRequired().HasMaxLength(32);
                entity.Property(e => e.Cep).IsRequired().HasMaxLength(9);
            });

            modelBuilder.Entity<AgendamentoModel>(entity =>
            {
                entity.ToTable("TB_RF_AGENDAMENTO");
                entity.HasKey(e => e.AgendamentoId);
                entity.Property(e => e.DataHoraAgendamento).HasColumnType("date");
                entity.HasOne(e => e.Morador)
                      .WithMany(m => m.Agendamentos)
                      .HasForeignKey(e => e.MoradorId);
                entity.HasMany(e => e.Residuos)
                      .WithOne(r => r.Agendamento)
                      .HasForeignKey(r => r.AgendamentoId);
                entity.HasOne(e => e.Rota)
                      .WithMany(r => r.Agendamentos)
                      .HasForeignKey(e => e.RotaId);
            });

            modelBuilder.Entity<ResiduoModel>(entity =>
            {
                entity.ToTable("TB_RF_RESIDUO");
                entity.HasKey(e => e.ResiduoId);
                entity.Property(e => e.ResiduoNome).IsRequired().HasMaxLength(64);
                entity.Property(e => e.TipoResiduo).IsRequired().HasMaxLength(12);
                entity.Property(e => e.QtdResiduo).HasMaxLength(32);
                entity.Property(e => e.MedidaResiduo).HasMaxLength(17);
            });

            modelBuilder.Entity<VeiculoModel>(entity =>
            {
                entity.ToTable("TB_RF_VEICULO");
                entity.HasKey(e => e.VeiculoId);
                entity.Property(e => e.PlacaVeiculo).IsRequired().HasMaxLength(16);
                entity.Property(e => e.NomeMotorista).IsRequired().HasMaxLength(64);
                entity.HasIndex(e => e.PlacaVeiculo).IsUnique();
                entity.HasMany(e => e.Rotas)
                      .WithOne(r => r.Veiculo)
                      .HasForeignKey(r => r.VeiculoId);
            });

            modelBuilder.Entity<RotaModel>(entity =>
            {
                entity.ToTable("TB_RF_ROTA");
                entity.HasKey(e => e.RotaId);
                entity.Property(e => e.DataHoraRota).HasColumnType("date");
                entity.Property(e => e.StatusRota).IsRequired().HasMaxLength(64);
                entity.HasMany(e => e.Agendamentos)
                      .WithOne(a => a.Rota)
                      .HasForeignKey(a => a.RotaId);
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
