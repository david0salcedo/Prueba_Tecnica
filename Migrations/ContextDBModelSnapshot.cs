﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEST.Repository;

#nullable disable

namespace TEST.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TEST.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CuentaId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("CuentaId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TEST.Models.Cuenta", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuentaId"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("NumeroCuenta")
                        .HasColumnType("int");

                    b.Property<double>("SaldoInicial")
                        .HasColumnType("float");

                    b.Property<int?>("TipoCuenta")
                        .HasColumnType("int");

                    b.HasKey("CuentaId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("TEST.Models.Movimiento", b =>
                {
                    b.Property<int>("MovimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovimientoId"));

                    b.Property<int?>("CuentaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<int>("TipoMovimiento")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("MovimientoId");

                    b.HasIndex("CuentaId");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("TEST.Models.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonaId"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("TEST.Models.Cliente", b =>
                {
                    b.HasOne("TEST.Models.Cuenta", "Cuenta")
                        .WithMany()
                        .HasForeignKey("CuentaId");

                    b.HasOne("TEST.Models.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.Navigation("Cuenta");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("TEST.Models.Movimiento", b =>
                {
                    b.HasOne("TEST.Models.Cuenta", null)
                        .WithMany("Movimientos")
                        .HasForeignKey("CuentaId");
                });

            modelBuilder.Entity("TEST.Models.Cuenta", b =>
                {
                    b.Navigation("Movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}
