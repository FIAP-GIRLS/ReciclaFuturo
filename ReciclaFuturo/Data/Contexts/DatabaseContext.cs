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
                entity.Property(e => e.MoradorId).HasMaxLength(5);
                entity.Property(e => e.ContatoNr).HasMaxLength(16);

                entity.HasOne(e => e.Endereco)
                      .WithMany()
                      .HasForeignKey(e => e.EnderecoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração para EnderecoModel, AgendamentoModel, ResiduoModel, VeiculoModel, RotaModel
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
