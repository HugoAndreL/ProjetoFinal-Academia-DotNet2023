using DesafioFinal.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Data
{
    public class HospitalContext : DbContext
    {
        //public DbSet<Senhas> Senhas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cargos> Cargos { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .Ignore(user => user.Cargo);

            builder.Entity<Usuario>()
                .HasOne(s => s.Cargo)
                .WithMany(h => h.Usuarios)
                .HasForeignKey(s => s.CargoId);

            //builder.Entity<Historico>().HasNoKey();
        }
    }
}
