﻿// <auto-generated />
using System;
using Autolote.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Autolote.Migrations
{
    [DbContext(typeof(AutoloteContext))]
    [Migration("20230523220012_CreandoBD")]
    partial class CreandoBD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Autolote.Models.Carro", b =>
                {
                    b.Property<int>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarroId"));

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CarroId");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("Autolote.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("ClienteNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Autolote.Models.Registro", b =>
                {
                    b.Property<int>("RegistroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegistroId"));

                    b.Property<int?>("CarroId")
                        .HasColumnType("int");

                    b.Property<string>("CarroMarca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CarroPrecio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("ClienteNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Cuota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SaldoCancelado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SaldoInsoluto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RegistroId");

                    b.HasIndex("CarroId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("Autolote.Models.Registro", b =>
                {
                    b.HasOne("Autolote.Models.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId");

                    b.HasOne("Autolote.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
