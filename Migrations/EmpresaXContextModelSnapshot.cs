// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebServicesEmpresaX.Model;

#nullable disable

namespace WebServicesEmpresaX.Migrations
{
    [DbContext(typeof(EmpresaXContext))]
    partial class EmpresaXContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebServicesEmpresaX.Model.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClienteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Apellidos")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombres")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebServicesEmpresaX.Model.Direccione", b =>
                {
                    b.Property<int>("DireccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DireccionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DireccionID"));

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteID");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("DireccionId")
                        .HasName("PK__Direccio__68906D44A44D629B");

                    b.HasIndex("ClienteId");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("WebServicesEmpresaX.Model.Direccione", b =>
                {
                    b.HasOne("WebServicesEmpresaX.Model.Cliente", "Cliente")
                        .WithMany("Direcciones")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK__Direccion__Clien__29572725");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("WebServicesEmpresaX.Model.Cliente", b =>
                {
                    b.Navigation("Direcciones");
                });
#pragma warning restore 612, 618
        }
    }
}
