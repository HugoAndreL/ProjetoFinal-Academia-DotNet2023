﻿using DesafioFinal.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Data
{
    public class HospitalContext : DbContext
    {
        //public DbSet<Senhas> Senhas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cargo> Cargos { get; set; }

        public DbSet<HistoricoUsuario> HistoricoUsuarios { get; set; }
        public DbSet<HistoricoCargo> HistoricoCargos { get; set; }

        public DbSet<TipoAreaAtendimento> TiposAreasAtendimento { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .Ignore(user => user.Cargo);

            builder.Entity<Usuario>()
                .HasOne(s => s.Cargo)
                .WithMany(h => h.Usuarios)
                .HasForeignKey(s => s.CargoId);

            builder.Entity<TipoAreaAtendimento>()
                .HasKey(t => t.COD);

            //builder.Entity<Historico>().HasNoKey();
        }
    }
}
