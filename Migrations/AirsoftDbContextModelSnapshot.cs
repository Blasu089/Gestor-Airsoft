﻿// <auto-generated />
using System;
using ApiAirsoft.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiAirsoft.Migrations
{
    [DbContext(typeof(AirsoftDbContext))]
    partial class AirsoftDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiAirsoft.Modelos.Armas.Accesorio", b =>
                {
                    b.Property<int>("Cod_Accesorio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Accesorio"), 1L, 1);

                    b.Property<int?>("Cod_Pedido")
                        .HasColumnType("int");

                    b.Property<int?>("Color_Id")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Cod_Accesorio");

                    b.HasIndex("Cod_Pedido");

                    b.HasIndex("Color_Id");

                    b.ToTable("Accesorios");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Armas.Accion", b =>
                {
                    b.Property<int>("Cod_Accion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Accion"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Cod_Accion");

                    b.ToTable("Acciones");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Armas.Arma", b =>
                {
                    b.Property<int>("Cod_Referencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Referencia"), 1L, 1);

                    b.Property<int?>("Accion_Id")
                        .HasColumnType("int");

                    b.Property<bool?>("Bipode_Incluido")
                        .HasColumnType("bit");

                    b.Property<int>("Capacidad_Cargador")
                        .HasColumnType("int");

                    b.Property<int?>("Capacidad_Cartucho")
                        .HasColumnType("int");

                    b.Property<bool?>("Cartuchos_Incluidos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("Cod_Pedido")
                        .HasColumnType("int");

                    b.Property<int?>("Color_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Disparo_Id")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HopUp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Longitud")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Mira_Incluida")
                        .HasColumnType("bit");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Potencia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TipoArma")
                        .HasColumnType("int");

                    b.Property<int>("Velocidad")
                        .HasColumnType("int");

                    b.HasKey("Cod_Referencia");

                    b.HasIndex("Accion_Id");

                    b.HasIndex("Cod_Pedido");

                    b.HasIndex("Color_Id");

                    b.HasIndex("Disparo_Id");

                    b.ToTable("Armas");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Armas.Disparo", b =>
                {
                    b.Property<int>("Cod_Disparo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Disparo"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Cod_Disparo");

                    b.ToTable("Disparos");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Clientes", b =>
                {
                    b.Property<int>("Cod_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Cliente"), 1L, 1);

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cod_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Color", b =>
                {
                    b.Property<int>("Cod_Color")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Color"), 1L, 1);

                    b.Property<string>("Hexadecimal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Cod_Color");

                    b.ToTable("Colores");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Pedidos", b =>
                {
                    b.Property<int>("Cod_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Pedido"), 1L, 1);

                    b.Property<int>("Cod_Cliente")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio_Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Cod_Pedido");

                    b.HasIndex("Cod_Cliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Usuario", b =>
                {
                    b.Property<int>("Cod_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Usuario"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nom_Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Cod_Usuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Armas.Accesorio", b =>
                {
                    b.HasOne("ApiAirsoft.Modelos.Pedidos", null)
                        .WithMany("Accesorios")
                        .HasForeignKey("Cod_Pedido")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ApiAirsoft.Modelos.Color", null)
                        .WithMany("Accesorios")
                        .HasForeignKey("Color_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Armas.Arma", b =>
                {
                    b.HasOne("ApiAirsoft.Modelos.Armas.Accion", null)
                        .WithMany("Armas")
                        .HasForeignKey("Accion_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiAirsoft.Modelos.Pedidos", null)
                        .WithMany("Armas")
                        .HasForeignKey("Cod_Pedido")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ApiAirsoft.Modelos.Color", null)
                        .WithMany("Armas")
                        .HasForeignKey("Color_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiAirsoft.Modelos.Armas.Disparo", null)
                        .WithMany("Armas")
                        .HasForeignKey("Disparo_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Pedidos", b =>
                {
                    b.HasOne("ApiAirsoft.Modelos.Clientes", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("Cod_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Armas.Accion", b =>
                {
                    b.Navigation("Armas");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Armas.Disparo", b =>
                {
                    b.Navigation("Armas");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Clientes", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Color", b =>
                {
                    b.Navigation("Accesorios");

                    b.Navigation("Armas");
                });

            modelBuilder.Entity("ApiAirsoft.Modelos.Pedidos", b =>
                {
                    b.Navigation("Accesorios");

                    b.Navigation("Armas");
                });
#pragma warning restore 612, 618
        }
    }
}
