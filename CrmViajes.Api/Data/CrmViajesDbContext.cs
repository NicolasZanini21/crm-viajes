using System;
using System.Collections.Generic;
using CrmViajes.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CrmViajes.Api.Data;

public partial class CrmViajesDbContext : DbContext
{
    public CrmViajesDbContext()
    {
    }

    public CrmViajesDbContext(DbContextOptions<CrmViajesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Destino> Destinos { get; set; }

    public virtual DbSet<EstadoReserva> EstadoReservas { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    public virtual DbSet<Pasajero> Pasajeros { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<CrmViajesDbContext>()
            .Build();

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasKey(e => e.IdDestino).HasName("destino_pkey");

            entity.ToTable("destino");

            entity.Property(e => e.IdDestino).HasColumnName("id_destino");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<EstadoReserva>(entity =>
        {
            entity.HasKey(e => e.IdEstadoReserva).HasName("estado_reserva_pkey");

            entity.ToTable("estado_reserva");

            entity.HasIndex(e => e.NombreEstado, "estado_reserva_nombre_estado_key").IsUnique();

            entity.Property(e => e.IdEstadoReserva).HasColumnName("id_estado_reserva");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(20)
                .HasColumnName("nombre_estado");
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.IdPaquete).HasName("paquete_pkey");

            entity.ToTable("paquete");

            entity.Property(e => e.IdPaquete).HasColumnName("id_paquete");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaRegreso).HasColumnName("fecha_regreso");
            entity.Property(e => e.FechaSalida).HasColumnName("fecha_salida");
            entity.Property(e => e.IdDestino).HasColumnName("id_destino");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioBase)
                .HasPrecision(10, 2)
                .HasColumnName("precio_base");

            entity.HasOne(d => d.IdDestinoNavigation).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.IdDestino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paquete_id_destino_fkey");
        });

        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.IdPasajero).HasName("pasajero_pkey");

            entity.ToTable("pasajero");

            entity.HasIndex(e => e.Dni, "pasajero_dni_key").IsUnique();

            entity.HasIndex(e => e.Email, "pasajero_email_key").IsUnique();

            entity.Property(e => e.IdPasajero).HasColumnName("id_pasajero");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FechaAlta)
                .HasDefaultValueSql("('now'::text)::date")
                .HasColumnName("fecha_alta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("reserva_pkey");

            entity.ToTable("reserva");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("('now'::text)::date")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.FechaUltimaActualizacion)
                .HasDefaultValueSql("('now'::text)::date")
                .HasColumnName("fecha_ultima_actualizacion");
            entity.Property(e => e.IdEstadoReserva).HasColumnName("id_estado_reserva");
            entity.Property(e => e.IdPaquete).HasColumnName("id_paquete");
            entity.Property(e => e.IdPasajero).HasColumnName("id_pasajero");
            entity.Property(e => e.MontoAcordado)
                .HasPrecision(10, 2)
                .HasColumnName("monto_acordado");

            entity.HasOne(d => d.IdEstadoReservaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdEstadoReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_id_estado_reserva_fkey");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_id_paquete_fkey");

            entity.HasOne(d => d.IdPasajeroNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdPasajero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_id_pasajero_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "usuario_email_key").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "usuario_nombre_usuario_key").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FechaAlta)
                .HasDefaultValueSql("('now'::text)::date")
                .HasColumnName("fecha_alta");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
