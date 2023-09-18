﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TpIntegradorSofttek.DataAccess;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TpIntegradorSofttek.Entities.Job", b =>
                {
                    b.Property<int>("CodJob")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codJob");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodJob"), 1L, 1);

                    b.Property<int>("AmountHours")
                        .HasColumnType("int")
                        .HasColumnName("amountHours");

                    b.Property<int>("CodProject")
                        .HasColumnType("int")
                        .HasColumnName("codProject");

                    b.Property<int>("CodService")
                        .HasColumnType("int")
                        .HasColumnName("codService");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<float>("HourValue")
                        .HasColumnType("real")
                        .HasColumnName("hourValue");

                    b.Property<float>("Price")
                        .HasColumnType("real")
                        .HasColumnName("price");

                    b.Property<bool>("state")
                        .HasColumnType("bit")
                        .HasColumnName("state");

                    b.HasKey("CodJob");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("TpIntegradorSofttek.Entities.Project", b =>
                {
                    b.Property<int>("CodProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codProject");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProject"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("name");

                    b.Property<bool>("State")
                        .HasColumnType("bit")
                        .HasColumnName("state");

                    b.HasKey("CodProject");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TpIntegradorSofttek.Entities.Service", b =>
                {
                    b.Property<int>("CodService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codService");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodService"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("description");

                    b.Property<float>("HourValue")
                        .HasColumnType("real")
                        .HasColumnName("hourValue");

                    b.Property<bool>("State")
                        .HasColumnType("bit")
                        .HasColumnName("state");

                    b.HasKey("CodService");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("TpIntegradorSofttek.Entities.User", b =>
                {
                    b.Property<int>("CodUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codUser");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUser"), 1L, 1);

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("dni");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasColumnName("password");

                    b.Property<int>("Type")
                        .HasColumnType("Int")
                        .HasColumnName("type");

                    b.Property<bool>("state")
                        .HasColumnType("bit")
                        .HasColumnName("state");

                    b.HasKey("CodUser");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            CodUser = 1,
                            Dni = "44504788",
                            Name = "Gabriel Baigorria",
                            Password = "1234",
                            Type = 1,
                            state = true
                        },
                        new
                        {
                            CodUser = 2,
                            Dni = "45000001",
                            Name = "Felipe Morato",
                            Password = "1234",
                            Type = 2,
                            state = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
