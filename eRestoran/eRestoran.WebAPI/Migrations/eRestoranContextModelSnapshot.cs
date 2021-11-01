﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eRestoran.WebAPI.Database;

namespace eRestoran.WebAPI.Migrations
{
    [DbContext(typeof(eRestoranContext))]
    partial class eRestoranContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eRestoran.WebAPI.Database.Jelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cijena")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Jelo");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("StatusNarudzbeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("StatusNarudzbeId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.StatusNarudzbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Naziv")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StatusNarudzbe");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.StavkeNarudzbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cijena")
                        .HasColumnType("int");

                    b.Property<int>("JeloId")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JeloId");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("StavkeNarudzbe");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Uposlenik", b =>
                {
                    b.Property<int>("UposlenikId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("NazivPosla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UposlenikId");

                    b.ToTable("Uposlenik");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Jelo", b =>
                {
                    b.HasOne("eRestoran.WebAPI.Database.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorija");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Narudzba", b =>
                {
                    b.HasOne("eRestoran.WebAPI.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestoran.WebAPI.Database.StatusNarudzbe", "StatusNarudzbe")
                        .WithMany()
                        .HasForeignKey("StatusNarudzbeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("StatusNarudzbe");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.StavkeNarudzbe", b =>
                {
                    b.HasOne("eRestoran.WebAPI.Database.Jelo", "Jelo")
                        .WithMany()
                        .HasForeignKey("JeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestoran.WebAPI.Database.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jelo");

                    b.Navigation("Narudzba");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Uposlenik", b =>
                {
                    b.HasOne("eRestoran.WebAPI.Database.Korisnik", "Korisnik")
                        .WithOne("Uposlenik")
                        .HasForeignKey("eRestoran.WebAPI.Database.Uposlenik", "UposlenikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Korisnik", b =>
                {
                    b.Navigation("Uposlenik");
                });
#pragma warning restore 612, 618
        }
    }
}
