using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebServicesEmpresaX.Model;

public partial class EmpresaXContext : DbContext
{
    public EmpresaXContext()
    {
    }

    public EmpresaXContext(DbContextOptions<EmpresaXContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=EmpresaX;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.DireccionId).HasName("PK__Direccio__68906D44A44D629B");

            entity.Property(e => e.DireccionId)
                .HasColumnName("DireccionID");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Sector)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Direccion__Clien__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
