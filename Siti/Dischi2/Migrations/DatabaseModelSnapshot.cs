﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dischi2.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Artisti");
                });

            modelBuilder.Entity("Disco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Anno")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id_artista")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id_genere")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Prezzo")
                        .HasColumnType("REAL");

                    b.Property<string>("Titolo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dischi");
                });

            modelBuilder.Entity("Genere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Generi");
                });
#pragma warning restore 612, 618
        }
    }
}
