using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace etvApi.Models
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
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<PermisoRol> PermisoRols { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<TipoTrabajo> TipoTrabajos { get; set; } = null!;
        public virtual DbSet<TipoUb> TipoUbs { get; set; } = null!;
        public virtual DbSet<Ub> Ubs { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=etv;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blindador>(entity =>
            {
                entity.HasKey(e => e.IdBlindador)
                    .HasName("PK__blindado__69434C1EDC9CDDDD");

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
                    .HasName("PK__cargo__3D0E29B8F5717DDA");

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
                    .HasName("PK__estadoUb__8F93987849AFB539");

                entity.ToTable("estadoUb");

                entity.Property(e => e.IdEstadoUb).HasColumnName("idEstadoUb");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__marca__70331812596766AC");

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
                    .HasName("PK__modelo__13A52CD13CE1893D");

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
                    .HasConstraintName("FK__modelo__idMarca__440B1D61");
            });

            modelBuilder.Entity<Ot>(entity =>
            {
                entity.HasKey(e => e.IdOt)
                    .HasName("PK__ot__9DB850DD309F11E6");

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
                    .HasConstraintName("FK__ot__idPersona__5BE2A6F2");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Ots)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ot__idSucursal__59FA5E80");

                entity.HasOne(d => d.IdTipoTrabajoNavigation)
                    .WithMany(p => p.Ots)
                    .HasForeignKey(d => d.IdTipoTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ot__idTipoTrabaj__5AEE82B9");
            });

            modelBuilder.Entity<OtDetalle>(entity =>
            {
                entity.HasKey(e => e.IdOtDetalle)
                    .HasName("PK__otDetall__03567D495D5F8E48");

                entity.ToTable("otDetalle");

                entity.Property(e => e.IdOtDetalle).HasColumnName("idOtDetalle");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(400)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdOt).HasColumnName("idOt");

                entity.Property(e => e.IdUb).HasColumnName("idUb");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("precio");

                entity.Property(e => e.TrabajoSolicitado)
                    .HasMaxLength(50)
                    .HasColumnName("trabajoSolicitado");

                entity.HasOne(d => d.IdOtNavigation)
                    .WithMany(p => p.OtDetalles)
                    .HasForeignKey(d => d.IdOt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__otDetalle__idOt__5EBF139D");

                entity.HasOne(d => d.IdUbNavigation)
                    .WithMany(p => p.OtDetalles)
                    .HasForeignKey(d => d.IdUb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__otDetalle__idUb__5FB337D6");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__permiso__06A584866CC9570F");

                entity.ToTable("permiso");

                entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<PermisoRol>(entity =>
            {
                entity.HasKey(e => e.IdPermisoRol)
                    .HasName("PK__permiso___BBE208F9FA51CF67");

                entity.ToTable("permiso_rol");

                entity.Property(e => e.IdPermisoRol).HasColumnName("idPermisoRol");

                entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.PermisoRols)
                    .HasForeignKey(d => d.IdPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__permiso_r__idPer__300424B4");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.PermisoRols)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__permiso_r__idRol__30F848ED");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__persona__A4788141EB22000B");

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
                    .HasConstraintName("FK__persona__idCargo__267ABA7A");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__rol__3C872F760DC08F28");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__sucursal__F707694C4BC61FBB");

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
                    .HasName("PK__tipoTrab__4893AC7193F61CD7");

                entity.ToTable("tipoTrabajo");

                entity.Property(e => e.IdTipoTrabajo).HasColumnName("idTipoTrabajo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoUb>(entity =>
            {
                entity.HasKey(e => e.IdTipoUb)
                    .HasName("PK__tipoUb__13ED3341DD665286");

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
                    .HasName("PK__ub__9DB800333857B004");

                entity.ToTable("ub");

                entity.Property(e => e.IdUb).HasColumnName("idUb");

                entity.Property(e => e.Ano)
                    .HasMaxLength(4)
                    .HasColumnName("ano");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .HasColumnName("codigo");

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
                    .HasConstraintName("FK__ub__estadoUb__52593CB8");

                entity.HasOne(d => d.IdBlindadorNavigation)
                    .WithMany(p => p.Ubs)
                    .HasForeignKey(d => d.IdBlindador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ub__idBlindador__534D60F1");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Ubs)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ub__idModelo__5441852A");

                entity.HasOne(d => d.IdTipoUbNavigation)
                    .WithMany(p => p.Ubs)
                    .HasForeignKey(d => d.IdTipoUb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ub__idTipoUb__5535A963");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6BB40260F");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(250)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__idRol__2B3F6F97");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
