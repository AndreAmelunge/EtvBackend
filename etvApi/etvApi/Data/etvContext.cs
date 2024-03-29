﻿using System;
using System.Collections.Generic;
using Etv.entities.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace etvApi.Data
{
    public partial class etvContext : DbContext
    {
        public etvContext()
        {
        }

        public etvContext(DbContextOptions<etvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blindador> Blindadors { get; set; } = null!;
        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<EstadoUb> EstadoUbs { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Ot> Ots { get; set; } = null!;
        public virtual DbSet<OtDetalle> OtDetalles { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<TipoTrabajo> TipoTrabajos { get; set; } = null!;
        public virtual DbSet<TipoUb> TipoUbs { get; set; } = null!;
        public virtual DbSet<Ub> Ubs { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blindador>(entity =>
            {
                entity.HasKey(e => e.IdBlindador)
                    .HasName("PK__blindado__69434C1E6D7F8448");

                entity.ToTable("blindador");

                entity.Property(e => e.IdBlindador).HasColumnName("idBlindador");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PK__cargo__3D0E29B86F2197FF");

                entity.ToTable("cargo");

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<EstadoUb>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUb)
                    .HasName("PK__estadoUb__8F939878FE0E59A1");

                entity.ToTable("estadoUb");

                entity.Property(e => e.IdEstadoUb).HasColumnName("idEstadoUb");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__marca__70331812009C1CED");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__modelo__13A52CD1862B7A93");

                entity.ToTable("modelo");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__modelo__idMarca__48CFD27E");
            });

            modelBuilder.Entity<Ot>(entity =>
            {
                entity.HasKey(e => e.IdOt)
                    .HasName("PK__ot__9DB850DD8CB7025E");

                entity.ToTable("ot");

                entity.Property(e => e.IdOt).HasColumnName("idOt");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(8)
                    .HasColumnName("codigo");

                entity.Property(e => e.FechaSolicitud)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaSolicitud");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.IdTipoTrabajo).HasColumnName("idTipoTrabajo");

                entity.Property(e => e.PrecioTotal)
                    .HasColumnType("money")
                    .HasColumnName("precioTotal");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Ots)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ot__idPersona__59063A47");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Ots)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ot__idSucursal__571DF1D5");

                entity.HasOne(d => d.IdTipoTrabajoNavigation)
                    .WithMany(p => p.Ots)
                    .HasForeignKey(d => d.IdTipoTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ot__idTipoTrabaj__5812160E");
            });

            modelBuilder.Entity<OtDetalle>(entity =>
            {
                entity.HasKey(e => e.IdOt)
                    .HasName("PK__otDetall__9DB850DDDB185D68");

                entity.ToTable("otDetalle");

                entity.Property(e => e.IdOt)
                    .ValueGeneratedNever()
                    .HasColumnName("idOt");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(400)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdUb).HasColumnName("idUb");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("precio");

                entity.Property(e => e.TrabajoSolicitado).HasColumnName("trabajoSolicitado");

                entity.HasOne(d => d.IdOtNavigation)
                    .WithOne(p => p.OtDetalle)
                    .HasForeignKey<OtDetalle>(d => d.IdOt)
                    .HasConstraintName("FK__otDetalle__idOt__5BE2A6F2");

                entity.HasOne(d => d.IdUbNavigation)
                    .WithMany(p => p.OtDetalles)
                    .HasForeignKey(d => d.IdUb)
                    .HasConstraintName("FK__otDetalle__idUb__5CD6CB2B");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__persona__A478814185CD030F");

                entity.ToTable("persona");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.AMaterno)
                    .HasMaxLength(50)
                    .HasColumnName("aMaterno");

                entity.Property(e => e.APaterno)
                    .HasMaxLength(50)
                    .HasColumnName("aPaterno");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__persona__idCargo__398D8EEE");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__rol__3C872F768E1DECEB");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__sucursal__F707694CFA8E7BE1");

                entity.ToTable("sucursal");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sigla)
                    .HasMaxLength(4)
                    .HasColumnName("sigla");
            });

            modelBuilder.Entity<TipoTrabajo>(entity =>
            {
                entity.HasKey(e => e.IdTipoTrabajo)
                    .HasName("PK__tipoTrab__4893AC7184D7B30C");

                entity.ToTable("tipoTrabajo");

                entity.Property(e => e.IdTipoTrabajo).HasColumnName("idTipoTrabajo");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoUb>(entity =>
            {
                entity.HasKey(e => e.IdTipoUb)
                    .HasName("PK__tipoUb__13ED3341FBF8641A");

                entity.ToTable("tipoUb");

                entity.Property(e => e.IdTipoUb).HasColumnName("idTipoUb");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Ub>(entity =>
            {
                entity.HasKey(e => e.IdUb)
                    .HasName("PK__ub__9DB800333A77F53D");

                entity.ToTable("ub");

                entity.Property(e => e.IdUb).HasColumnName("idUb");

                entity.Property(e => e.Ano)
                    .HasMaxLength(4)
                    .HasColumnName("ano");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .HasColumnName("codigo");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.EstadoUb).HasColumnName("estadoUb");

                entity.Property(e => e.IdBlindador).HasColumnName("idBlindador");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.IdTipoUb).HasColumnName("idTipoUb");

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .HasColumnName("placa");

                entity.Property(e => e.TarjetaOperativa)
                    .HasMaxLength(8)
                    .HasColumnName("tarjetaOperativa");

                entity.HasOne(d => d.EstadoUbNavigation)
                    .WithMany(p => p.Ubs)
                    .HasForeignKey(d => d.EstadoUb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ub__estadoUb__4F7CD00D");

                entity.HasOne(d => d.IdBlindadorNavigation)
                    .WithMany(p => p.Ubs)
                    .HasForeignKey(d => d.IdBlindador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ub__idBlindador__5070F446");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Ubs)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ub__idModelo__5165187F");

                entity.HasOne(d => d.IdTipoUbNavigation)
                    .WithMany(p => p.Ubs)
                    .HasForeignKey(d => d.IdTipoUb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ub__idTipoUb__52593CB8");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__usuario__A478814154288060");

                entity.ToTable("usuario");

                entity.Property(e => e.IdPersona)
                    .ValueGeneratedNever()
                    .HasColumnName("idPersona");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(250)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__idPerso__403A8C7D");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__idRol__412EB0B6");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__idSucur__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
