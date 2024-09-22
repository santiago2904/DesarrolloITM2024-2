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
    [Migration("20240922203731_UpdateClienteCreditoType")]
    partial class UpdateClienteCreditoType
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

            modelBuilder.Entity("TallerDesarrollo.models.Cliente", b =>
                {
                    b.HasBaseType("TallerDesarrollo.models.Persona");

                    b.Property<decimal>("Credito")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("EmpresaCodigo")
                        .HasColumnType("int");

                    b.HasIndex("EmpresaCodigo");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("TallerDesarrollo.models.Cliente", b =>
                {
                    b.HasOne("TallerDesarrollo.models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaCodigo");

                    b.Navigation("Empresa");
                });
#pragma warning restore 612, 618
        }
    }
}
