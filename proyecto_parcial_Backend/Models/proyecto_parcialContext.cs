using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proyecto_parcial_Backend.Models
{
    public partial class proyecto_parcialContext : DbContext
    {
        public proyecto_parcialContext()
        {
        }

        public proyecto_parcialContext(DbContextOptions<proyecto_parcialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Cita { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Mascota> Mascota { get; set; } = null!;
        public virtual DbSet<Reporte> Reportes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__Cita__394B02029A6F6A51");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.oMascota)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdMascota)
                    .HasConstraintName("FK__Cita__FechaAgend__503BEA1C");

                entity.HasOne(d => d.oUsuario)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Cita__IdUsuario__51300E55");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Factura__50E7BAF17BF78E63");

                entity.ToTable("Factura");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Costos).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCita).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.oCita)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCita)
                    .HasConstraintName("FK__Factura__IdCita__5BAD9CC8");

                entity.HasOne(d => d.oMascota)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdMascota)
                    .HasConstraintName("FK__Factura__IdMasco__5AB9788F");

                entity.HasOne(d => d.oUsuario)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Factura__IdUsuar__5CA1C101");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PK__Inventar__1927B20CC4C1D423");

                entity.ToTable("Inventario");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCita).HasColumnType("date");

                entity.Property(e => e.NombrePet)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.oCita)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdCita)
                    .HasConstraintName("FK__Inventari__IdCit__57DD0BE4");

                entity.HasOne(d => d.oMascota)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdMascota)
                    .HasConstraintName("FK__Inventari__IdMas__56E8E7AB");
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.IdMascota)
                    .HasName("PK__Mascota__5C9C26F09CB0A082");

                entity.Property(e => e.Antecedentes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Castrado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePet)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Raza)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte)
                    .HasName("PK__Reporte__F9561136EC521CBA");

                entity.ToTable("Reporte");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCita).HasColumnType("date");

                entity.Property(e => e.NombrePet)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.oMascota)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdMascota)
                    .HasConstraintName("FK_IdMascota");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97E1E3B3F9");

                entity.ToTable("Usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
