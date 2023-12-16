﻿// <auto-generated />
using System;
using DesafioFinal.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioFinal.Server.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20231216200818_Senha")]
    partial class Senha
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesafioFinal.Server.Models.AreaAtendimento", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.Property<int>("TipoAreaAtendimentoId")
                        .HasColumnType("int");

                    b.HasKey("Numero");

                    b.HasIndex("TipoAreaAtendimentoId");

                    b.ToTable("AreasAtendimento");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Cargo", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.HistoricoCargo", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero");

                    b.ToTable("HistoricoCargos");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.HistoricoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("HistoricoUsuarios");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Senha", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Numero");

                    b.ToTable("Senhas");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.TipoAreaAtendimento", b =>
                {
                    b.Property<int>("COD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("COD"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("COD");

                    b.ToTable("TiposAreasAtendimento");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.AreaAtendimento", b =>
                {
                    b.HasOne("DesafioFinal.Server.Models.TipoAreaAtendimento", "TipoAreaAtendimento")
                        .WithMany("AreasAtendimento")
                        .HasForeignKey("TipoAreaAtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoAreaAtendimento");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Usuario", b =>
                {
                    b.HasOne("DesafioFinal.Server.Models.Cargo", "Cargo")
                        .WithMany("Usuarios")
                        .HasForeignKey("CargoId");

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Cargo", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.TipoAreaAtendimento", b =>
                {
                    b.Navigation("AreasAtendimento");
                });
#pragma warning restore 612, 618
        }
    }
}
