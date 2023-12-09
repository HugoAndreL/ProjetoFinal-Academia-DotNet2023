using DesafioFinal.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Senhas> Senhas { get; set; }

        public DbSet<SenhasGuiches> SenhasGuiches { get; set; }
        public DbSet<Guiche> Guiches { get; set; }

        public DbSet<SenhasTriagem> SenhasTriagens { get; set; }
        public DbSet<Triagem> Triagens { get; set; }

        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<SenhasConsultorios> SenhasConsultorios { get; set; }

        public DbSet<Historico> Historico { get; set; }

        public Contexto() {}

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseSqlServer("Data Source=HGNOTEBOOK;Initial Catalog=Hospitalar_senhas;Persist Security Info=True;User ID=HospitalAdmin;Password=admin;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            // FK 1 Historico N Senhas
            builder.Entity<Senhas>()
                .HasOne(senha => senha.Historico)
                .WithMany(his => his.SenhasHistorico)
                // Configurando a foreign key para ser configurada no banco
                .HasForeignKey(senha => senha.HistoricoId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // FK N Senhas N Guiches
            // 1. Configuramos a classe SenhasGuiches para ter dua PK
            builder.Entity<SenhasGuiches>()
                .HasKey(sg => new
                {
                    sg.SenhaId,
                    sg.GuicheId
                });
            
            // 2. Agora Configuramos duas FK 1:N na SenhasGuiches
            builder.Entity<SenhasGuiches>()
                .HasOne(sg => sg.Senha)
                .WithMany(senha => senha.SenhasGuiches)
                .HasForeignKey(sg => sg.SenhaId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<SenhasGuiches>()
                .HasOne(sg => sg.Guiche)
                .WithMany(guiche => guiche.SenhasGuiches)
                .HasForeignKey(sg => sg.GuicheId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // FK N Senhas N Triagem
            builder.Entity<SenhasTriagem>()
                .HasKey(st => new
                {
                    st.SenhaId,
                    st.TriagemId
                });

            builder.Entity<SenhasTriagem>()
                .HasOne(st => st.Senha)
                .WithMany(senha => senha.SenhasTriagem)
                .HasForeignKey(sg => sg.SenhaId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<SenhasTriagem>()
                .HasOne(st => st.Triagem)
                .WithMany(guiche => guiche.SenhasTriagem)
                .HasForeignKey(st => st.TriagemId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // FK N Senhas N Consultorios
            builder.Entity<SenhasConsultorios>()
                .HasKey(sc => new
                {
                    sc.SenhaId,
                    sc.ConsultorioId
                });

            builder.Entity<SenhasConsultorios>()
                .HasOne(sc => sc.Senha)
                .WithMany(senha => senha.SenhasConsultorios)
                .HasForeignKey(sc => sc.SenhaId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<SenhasConsultorios>()
                .HasOne(sc => sc.Consultorio)
                .WithMany(consult => consult.SenhasConsultorios)
                .HasForeignKey(sc => sc.ConsultorioId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
