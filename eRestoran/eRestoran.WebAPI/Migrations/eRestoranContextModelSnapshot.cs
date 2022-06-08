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

            modelBuilder.Entity("eRestoran.WebAPI.Database.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drzava");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Bosna i Hercegovina"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Test"
                        });
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grad");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Mostar"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Sarajevo"
                        },
                        new
                        {
                            Id = 3,
                            Naziv = "Tuzla"
                        });
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Jelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Jelo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cijena = 5m,
                            KategorijaId = 1,
                            Naziv = "Hamburger",
                            Opis = "Opis za hamburger"
                        },
                        new
                        {
                            Id = 2,
                            Cijena = 6m,
                            KategorijaId = 1,
                            Naziv = "Cevapi",
                            Opis = "Opis za Cevapi"
                        },
                        new
                        {
                            Id = 3,
                            Cijena = 4m,
                            KategorijaId = 2,
                            Naziv = "Test",
                            Opis = "Opis test"
                        });
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorija");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Predjelo",
                            Opis = "Opis k1"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Glavno Jelo",
                            Opis = "Opis k2"
                        },
                        new
                        {
                            Id = 3,
                            Naziv = "Desert",
                            Opis = "Opis k3"
                        });
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<int>("GradId")
                        .HasColumnType("int");

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

                    b.HasIndex("DrzavaId");

                    b.HasIndex("GradId");

                    b.ToTable("Korisnik");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DrzavaId = 1,
                            GradId = 2,
                            Ime = "Admin",
                            KorisnickoIme = "admin",
                            LozinkaHash = "rDEPtSFBJDTdiU9UDDlQP91clpYcq5LUIeUWoU7S134=",
                            LozinkaSalt = "phzA+nctd0u9yWY7w4h9xw==",
                            Prezime = "admin"
                        },
                        new
                        {
                            Id = 2,
                            DrzavaId = 1,
                            GradId = 2,
                            Ime = "test",
                            KorisnickoIme = "test",
                            LozinkaHash = "peVsycdT/s0A+yZBMdrgGNpeHAO2JqkfhkcnH8jnvpI=",
                            LozinkaSalt = "pFtLSSxOAfiUGrJzEjS7qA==",
                            Prezime = "test"
                        },
                        new
                        {
                            Id = 3,
                            DrzavaId = 1,
                            GradId = 2,
                            Ime = "John",
                            KorisnickoIme = "johnDoe",
                            LozinkaHash = "BlouC47PYmgibrpTRzqHP0iYtBA5CZcC2LPM4/6Zvd4=",
                            LozinkaSalt = "nzHvrGo1/oFpyTCdLOQSwA==",
                            Prezime = "Doe"
                        },
                        new
                        {
                            Id = 4,
                            DrzavaId = 1,
                            GradId = 2,
                            Ime = "Some",
                            KorisnickoIme = "myUsername",
                            LozinkaHash = "4By3U21zPO2Ml+VAXRNcYvkMrI1hN6W4AOpLBSMCzl8=",
                            LozinkaSalt = "1dHqc3t/DvzLGBz3PySslg==",
                            Prezime = "User"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DatumNarudzbe = new DateTime(2022, 6, 8, 16, 48, 56, 715, DateTimeKind.Local).AddTicks(864),
                            KorisnikId = 1,
                            StatusNarudzbeId = 1
                        });
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Recenzija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JeloId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JeloId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Recenzija");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            JeloId = 1,
                            KorisnikId = 1,
                            Ocjena = 3,
                            Opis = "abc123"
                        },
                        new
                        {
                            Id = 2,
                            JeloId = 2,
                            KorisnikId = 1,
                            Ocjena = 3,
                            Opis = "cba123"
                        },
                        new
                        {
                            Id = 3,
                            JeloId = 1,
                            KorisnikId = 2,
                            Ocjena = 4,
                            Opis = "def123"
                        },
                        new
                        {
                            Id = 4,
                            JeloId = 2,
                            KorisnikId = 2,
                            Ocjena = 4,
                            Opis = "fed123"
                        });
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.StatusNarudzbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusNarudzbe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Primljena"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "U pripremi"
                        },
                        new
                        {
                            Id = 3,
                            Naziv = "Isporucena"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cijena = 5,
                            JeloId = 1,
                            Kolicina = 2,
                            NarudzbaId = 1
                        });
                });

            modelBuilder.Entity("eRestoran.WebAPI.Database.Uplata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTransakcije")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumTransakcije")
                        .HasColumnType("datetime2");

                    b.Property<double>("Iznos")
                        .HasColumnType("float");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Uplata");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DatumTransakcije = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Iznos = 10.0,
                            KorisnikId = 1
                        },
                        new
                        {
                            Id = 2,
                            DatumTransakcije = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Iznos = 10.0,
                            KorisnikId = 1
                        },
                        new
                        {
                            Id = 3,
                            DatumTransakcije = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Iznos = 20.0,
                            KorisnikId = 2
                        },
                        new
                        {
                            Id = 4,
                            DatumTransakcije = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Iznos = 5.0,
                            KorisnikId = 3
                        },
                        new
                        {
                            Id = 5,
                            DatumTransakcije = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Iznos = 7.0,
                            KorisnikId = 4
                        });
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

            modelBuilder.Entity("eRestoran.WebAPI.Database.Korisnik", b =>
                {
                    b.HasOne("eRestoran.WebAPI.Database.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestoran.WebAPI.Database.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");

                    b.Navigation("Grad");
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

            modelBuilder.Entity("eRestoran.WebAPI.Database.Recenzija", b =>
                {
                    b.HasOne("eRestoran.WebAPI.Database.Jelo", "Jelo")
                        .WithMany()
                        .HasForeignKey("JeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestoran.WebAPI.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jelo");

                    b.Navigation("Korisnik");
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

            modelBuilder.Entity("eRestoran.WebAPI.Database.Uplata", b =>
                {
                    b.HasOne("eRestoran.WebAPI.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
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
