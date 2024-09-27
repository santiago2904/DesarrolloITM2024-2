﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TallerDesarrollo.config;

#nullable disable

namespace TallerDesarrollo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240927205101_deletekeyKeyINfacturaProducto")]
    partial class deletekeyKeyINfacturaProducto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TallerDesarrollo.models.Empresa", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("TallerDesarrollo.models.Factura", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.Property<double?>("Total")
                        .HasColumnType("float");

                    b.HasKey("Codigo");

                    b.HasIndex("PersonaId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("TallerDesarrollo.models.FacturaProducto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.HasKey("Codigo");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("FacturaProductos");
                });

            modelBuilder.Entity("TallerDesarrollo.models.Persona", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Personas");

                    b.HasDiscriminator().HasValue("Persona");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TallerDesarrollo.models.Producto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.Property<double?>("Valorunitario")
                        .HasColumnType("float");

                    b.HasKey("Codigo");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("TallerDesarrollo.models.Cliente", b =>
                {
                    b.HasBaseType("TallerDesarrollo.models.Persona");

                    b.Property<decimal>("Credito")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmpresaCodigo")
                        .HasColumnType("int");

                    b.HasIndex("EmpresaCodigo");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("TallerDesarrollo.models.Vendedor", b =>
                {
                    b.HasBaseType("TallerDesarrollo.models.Persona");

                    b.Property<string>("Carne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Vendedor");
                });

            modelBuilder.Entity("TallerDesarrollo.models.Factura", b =>
                {
                    b.HasOne("TallerDesarrollo.models.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("TallerDesarrollo.models.FacturaProducto", b =>
                {
                    b.HasOne("TallerDesarrollo.models.Factura", "Factura")
                        .WithMany("FacturaProductos")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TallerDesarrollo.models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("TallerDesarrollo.models.Cliente", b =>
                {
                    b.HasOne("TallerDesarrollo.models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("TallerDesarrollo.models.Factura", b =>
                {
                    b.Navigation("FacturaProductos");
                });
#pragma warning restore 612, 618
        }
    }
}
