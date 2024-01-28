using System;
using System.Collections.Generic;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Persistencia;

public partial class DbIntegradorContext : DbContext
{
    public DbIntegradorContext()
    {
    }

    public DbIntegradorContext(DbContextOptions<DbIntegradorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinica> Clinicas { get; set; }

    public virtual DbSet<ClinicaUsuario> ClinicaUsuarios { get; set; }

    public virtual DbSet<DotorEspecialidad> DotorEspecialidads { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Ficha> Fichas { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoAtencion> TipoAtencions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\MSQLEXPRESS;Initial Catalog=DB_Integrador;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clinica__3213E83FB5130CA1");

            entity.ToTable("Clinica");

            entity.HasIndex(e => e.ClinicaNombre, "UQ__Clinica__5AB1F040A5E146F1").IsUnique();

            entity.HasIndex(e => e.Ruc, "UQ__Clinica__C2B74E612FF8E526").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClinicaNombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Clinica_nombre");
            entity.Property(e => e.Codigo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Ruc)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ruc");
        });

        modelBuilder.Entity<ClinicaUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clinica___3213E83FFF06D19B");

            entity.ToTable("Clinica_Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clinica).HasColumnName("clinica");
            entity.Property(e => e.Usuario).HasColumnName("usuario");

            entity.HasOne(d => d.ClinicaNavigation).WithMany(p => p.ClinicaUsuarios)
                .HasForeignKey(d => d.Clinica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clinica_U__clini__6A30C649");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.ClinicaUsuarios)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clinica_U__usuar__693CA210");
        });

        modelBuilder.Entity<DotorEspecialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dotor_es__3213E83FCC20FFF2");

            entity.ToTable("dotor_especialidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocId).HasColumnName("doc_id");
            entity.Property(e => e.EspecialidadId).HasColumnName("especialidad_id");

            entity.HasOne(d => d.Doc).WithMany(p => p.DotorEspecialidads)
                .HasForeignKey(d => d.DocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dotor_esp__doc_i__6754599E");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.DotorEspecialidads)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dotor_esp__espec__68487DD7");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__especial__3213E83F7073514D");

            entity.ToTable("especialidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EArea)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("e_area");
            entity.Property(e => e.ECodigo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("e_codigo");
            entity.Property(e => e.EDecripcion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("e_decripcion");
            entity.Property(e => e.EDescripcion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("e_descripcion");
            entity.Property(e => e.ENomre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("e_nomre");
        });

        modelBuilder.Entity<Ficha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ficha__3213E83FD5DD1904");

            entity.ToTable("ficha");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.DocId).HasColumnName("doc_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasColumnType("datetime")
                .HasColumnName("hora");
            entity.Property(e => e.UsuId).HasColumnName("usu_id");

            entity.HasOne(d => d.Doc).WithMany(p => p.FichaDocs)
                .HasForeignKey(d => d.DocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ficha__doc_id__66603565");

            entity.HasOne(d => d.Usu).WithMany(p => p.FichaUsus)
                .HasForeignKey(d => d.UsuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ficha__usu_id__656C112C");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__logs__3213E83F9D1C5EF1");

            entity.ToTable("logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Intentos).HasColumnName("intentos");
            entity.Property(e => e.Usuario).HasColumnName("usuario");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__logs__usuario__6C190EBB");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reserva__3213E83F81AD8987");

            entity.ToTable("reserva");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AtId).HasColumnName("at_id");
            entity.Property(e => e.CliId).HasColumnName("cli_id");
            entity.Property(e => e.DocId).HasColumnName("doc_id");
            entity.Property(e => e.EspecialidadId).HasColumnName("especialidad_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Sintomas)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sintomas");
            entity.Property(e => e.UsId).HasColumnName("us_id");

            entity.HasOne(d => d.At).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.AtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reserva__at_id__628FA481");

            entity.HasOne(d => d.Cli).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.CliId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reserva__cli_id__6383C8BA");

            entity.HasOne(d => d.Doc).WithMany(p => p.ReservaDocs)
                .HasForeignKey(d => d.DocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reserva__doc_id__619B8048");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reserva__especia__6477ECF3");

            entity.HasOne(d => d.Us).WithMany(p => p.ReservaUs)
                .HasForeignKey(d => d.UsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reserva__us_id__60A75C0F");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol__3213E83FF8EDDE61");

            entity.ToTable("rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rol1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Usuario).HasColumnName("usuario");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Rols)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rol__usuario__6B24EA82");
        });

        modelBuilder.Entity<TipoAtencion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoAten__3213E83F168633DA");

            entity.ToTable("TipoAtencion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TAtencionLocal)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("t_atencionLocal");
            entity.Property(e => e.TOnline)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("t_online");
            entity.Property(e => e.TPrecencial)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("t_precencial");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83F52576278");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Correo, "UQ__usuario__2A586E0B786E5643").IsUnique();

            entity.HasIndex(e => e.Celular, "UQ__usuario__2E4973E7347869AA").IsUnique();

            entity.HasIndex(e => e.Dni, "UQ__usuario__D87608A74EA4F4E9").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__usuario__F3DBC57298F37574").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Celular)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Psw)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("psw");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("tipoDocumento");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
