using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDvideojuegos.Models;

public partial class VideojuegosContext : DbContext
{
    public VideojuegosContext()
    {
    }

    public VideojuegosContext(DbContextOptions<VideojuegosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consola> Consolas { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Videojuego> Videojuegos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-GR8CGSF\\SQLEXPRESS; DataBase=Videojuegos;Integrated Security=true; Encrypt=False");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consola>(entity =>
        {
            entity.HasKey(e => e.IdConsola);

            entity.ToTable("Consola");

            entity.Property(e => e.FechaReg).HasColumnType("date");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreConsola)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero);

            entity.ToTable("Genero");

            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Videojuego>(entity =>
        {
            entity.HasKey(e => e.IdVideojuego);

            entity.ToTable("Videojuego");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.FechaLanzamiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
