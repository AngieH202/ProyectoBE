using BackEndAngie.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace BackEndAngie.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Productos> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>().ToTable("usuario");

        modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("nombre");
        modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("correo");
        modelBuilder.Entity<Usuario>().Property(u => u.Contraseña).HasColumnName("contraseña");
        modelBuilder.Entity<Usuario>().Property(u => u.CreatedAt).HasColumnName("created_at");

        // Configuración para las productos
        modelBuilder.Entity<Productos>().ToTable("productos");
        modelBuilder.Entity<Productos>().Property(t => t.Nombre).HasColumnName("nombre");
        modelBuilder.Entity<Productos>().Property(t => t.Categoria).HasColumnName("categoria");
        modelBuilder.Entity<Productos>().Property(u => u.Precio).HasColumnName("precio");
        modelBuilder.Entity<Productos>().Property(u => u.Cantidad).HasColumnName("cantidad");

    }

}
