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

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Médico> Médicos { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservasDoctor> ReservasDoctors { get; set; }

    public virtual DbSet<TipoAtencionReserva> TipoAtencionReservas { get; set; }

    public virtual DbSet<TiposAtencion> TiposAtencions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\MSQLEXPRESS;Initial Catalog=DB_Integrador;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clinicas__3213E83F76ADAA03");

            entity.HasIndex(e => e.ClinicaNombre, "UQ__Clinicas__5AB1F0407E597289").IsUnique();

            entity.HasIndex(e => e.Ruc, "UQ__Clinicas__C2B74E618F8F16DF").IsUnique();

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
            entity.Property(e => e.DoId).HasColumnName("do_id");
            entity.Property(e => e.Ruc)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.TiId).HasColumnName("ti_id");

            entity.HasOne(d => d.Do).WithMany(p => p.Clinicas)
                .HasForeignKey(d => d.DoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clinicas__do_id__5AEE82B9");

            entity.HasOne(d => d.Ti).WithMany(p => p.Clinicas)
                .HasForeignKey(d => d.TiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clinicas__ti_id__5BE2A6F2");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__especial__3213E83F717A241A");

            entity.ToTable("especialidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DoId).HasColumnName("do_id");
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

            entity.HasOne(d => d.Do).WithMany(p => p.Especialidads)
                .HasForeignKey(d => d.DoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__especiali__do_id__628FA481");
        });

        modelBuilder.Entity<Médico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Médicos__3213E83F3D4CECA1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DApellido)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("d_apellido");
            entity.Property(e => e.DArea)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("d_area");
            entity.Property(e => e.DDni)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("d_dni");
            entity.Property(e => e.DNombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("d_nombre");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__registro__3213E83FFC75A6B9");

            entity.ToTable("registros");

            entity.HasIndex(e => e.Correo, "UQ__registro__2A586E0BAE74C058").IsUnique();

            entity.HasIndex(e => e.Celular, "UQ__registro__2E4973E7999F8750").IsUnique();

            entity.HasIndex(e => e.Dni, "UQ__registro__D87608A7AB65E62C").IsUnique();

            entity.HasIndex(e => e.Psw, "UQ__registro__DD37A9EEFAD6F5A2").IsUnique();

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
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservas__3213E83F52E8487B");

            entity.ToTable("reservas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DesPa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("des_pa");
            entity.Property(e => e.DoId).HasColumnName("do_id");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.SuId).HasColumnName("su_id");
            entity.Property(e => e.UsId).HasColumnName("us_id");

            entity.HasOne(d => d.Do).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.DoId)
                .HasConstraintName("FK_reservas_Medicos");

            entity.HasOne(d => d.Us).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reservas__us_id__5629CD9C");
        });

        modelBuilder.Entity<ReservasDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservas__3213E83F15BD14C0");

            entity.ToTable("reservasDoctor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DoId).HasColumnName("do_id");
            entity.Property(e => e.ReserId).HasColumnName("reser_id");

            entity.HasOne(d => d.Do).WithMany(p => p.ReservasDoctors)
                .HasForeignKey(d => d.DoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reservasD__do_id__5FB337D6");

            entity.HasOne(d => d.Reser).WithMany(p => p.ReservasDoctors)
                .HasForeignKey(d => d.ReserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reservasD__reser__5EBF139D");
        });

        modelBuilder.Entity<TipoAtencionReserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoAten__3213E83F478AA884");

            entity.ToTable("TipoAtencion_Reservas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReseId).HasColumnName("rese_id");
            entity.Property(e => e.TiId).HasColumnName("ti_id");

            entity.HasOne(d => d.Rese).WithMany(p => p.TipoAtencionReservas)
                .HasForeignKey(d => d.ReseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoAtenc__rese___66603565");

            entity.HasOne(d => d.Ti).WithMany(p => p.TipoAtencionReservas)
                .HasForeignKey(d => d.TiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoAtenc__ti_id__656C112C");
        });

        modelBuilder.Entity<TiposAtencion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TiposAte__3213E83F16942B69");

            entity.ToTable("TiposAtencion");

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
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83FCCE4AE48");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReId).HasColumnName("re_id");

            entity.HasOne(d => d.Re).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.ReId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__re_id__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
