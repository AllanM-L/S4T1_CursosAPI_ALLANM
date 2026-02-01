using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CursosAPI.Models;

public partial class CursosContext : DbContext
{
    public CursosContext()
    {
    }

    public CursosContext(DbContextOptions<CursosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=cursos_db;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cursos");

            entity.HasIndex(e => e.ProfesorId, "cursos_ibfk_1");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Duracion)
                .HasColumnType("int(11)")
                .HasColumnName("duracion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.ProfesorId).HasColumnType("int(11)");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.ProfesorId)
                .HasConstraintName("cursos_ibfk_1");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estudiantes");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("evaluaciones");

            entity.HasIndex(e => e.InscripcionId, "evaluaciones_ibfk_1");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.InscripcionId).HasColumnType("int(11)");
            entity.Property(e => e.Nota)
                .HasPrecision(5, 2)
                .HasColumnName("nota");
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .HasColumnName("observacion");

            entity.HasOne(d => d.Inscripcion).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.InscripcionId)
                .HasConstraintName("evaluaciones_ibfk_1");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inscripciones");

            entity.HasIndex(e => e.EstudianteId, "inscripciones_ibfk_1");

            entity.HasIndex(e => e.CursoId, "inscripciones_ibfk_2");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CursoId).HasColumnType("int(11)");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.EstudianteId).HasColumnType("int(11)");
            entity.Property(e => e.Fecha).HasColumnName("fecha");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("inscripciones_ibfk_2");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.EstudianteId)
                .HasConstraintName("inscripciones_ibfk_1");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("profesores");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
