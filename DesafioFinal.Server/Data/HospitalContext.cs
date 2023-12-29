using DesafioFinal.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Senha> Senhas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cargo> Cargos { get; set; }

        public DbSet<HistoricoSenha> HistoricoSenhas { get; set; }
        public DbSet<HistoricoUsuario> HistoricoUsuarios { get; set; }
        public DbSet<HistoricoCargo> HistoricoCargos { get; set; }

        public DbSet<AreaAtendimento> AreasAtendimento { get; set; }

        public DbSet<TipoAreaAtendimento> TiposAreasAtendimento { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<Relatorio> Relatorios { get; set; }

        public DbSet<Funcionalidade> Funcionalidades { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .HasOne(user => user.Login)
                .WithOne(log => log.Usuario)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Usuario>()
                .HasOne(s => s.Cargo)
                .WithMany(h => h.Usuarios)
                .HasForeignKey(s => s.CargoId);

            builder.Entity<AreaAtendimento>()
                .HasOne(aa => aa.TipoAreaAtendimento)
                .WithMany(taa => taa.AreasAtendimento)
                .HasForeignKey(aa => aa.TipoAreaAtendimentoId);

            builder.Entity<Funcionalidade>()
                .HasOne(func => func.Cargo)
                .WithMany(cargo => cargo.Funcionalidades)
                .HasForeignKey(func => func.CargoId);
        }
    }
}
