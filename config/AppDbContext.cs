using TallerDesarrollo.models;

namespace TallerDesarrollo.config;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    private const string ConnectionString =
        "Server=localhost;Database=tallerDesarrollo;User Id=sa;Password=2283779.coM;TrustServerCertificate=True;";

    public DbSet<Persona> Personas { get; set; } // Tabla Personas
    public DbSet<Cliente> Clientes { get; set; } // Tabla Clientes
    public DbSet<Empresa> Empresas { get; set; } // Tabla Empresas
    public DbSet<Producto> Productos { get; set; } // Tabla Usuarios
    public DbSet<ProductoPorFactura> ProductosPorFactura { get; set; } // Tabla Usuarios

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Usa el método de configuración desde Config.cs
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .Property(c => c.Credito)
            .HasColumnType("decimal(18,2)"); 
        // Especifica precisión y escala
        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Empresa)
            .WithMany() // Asegúrate de que aquí se ajuste si hay una colección de Clientes en Empresa
            .HasForeignKey(c => c.EmpresaCodigo);
    }
}