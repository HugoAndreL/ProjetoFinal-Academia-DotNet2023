﻿// <auto-generated />
using System;
using DesafioFinal.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioFinal.Server.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesafioFinal.Server.Models.AreaAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("TipoAreaAtendimentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoAreaAtendimentoId");

                    b.ToTable("AreasAtendimento");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Funcionalidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Funcionalidades");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.HistoricoCargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("HistoricoCargos");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.HistoricoSenha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("HistoricoSenhas");
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

            modelBuilder.Entity("DesafioFinal.Server.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Relatorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DataRelatorio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int>("TaxaUtilizacaoConsultorio")
                        .HasColumnType("int");

                    b.Property<int>("TaxaUtilizacaoGuiche")
                        .HasColumnType("int");

                    b.Property<int>("TaxaUtilizacaoTriagem")
                        .HasColumnType("int");

                    b.Property<string>("TempoEspera")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.HasKey("Id");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.Senha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Senhas");
                });

            modelBuilder.Entity("DesafioFinal.Server.Models.TipoAreaAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

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

                    b.Property<string>("Senha")
                        .HasColumnType("VARCHAR(20)");

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

            modelBuilder.Entity("DesafioFinal.Server.Models.Funcionalidade", b =>
                {
                    b.HasOne("DesafioFinal.Server.Models.Cargo", "Cargo")
                        .WithMany("Funcionalidades")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
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
                    b.Navigation("Funcionalidades");

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
