using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Database
{
    public partial class eRestoranContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            List<string> salts = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                salts.Add(PasswordHelper.GenerateSalt());
            }

            modelBuilder.Entity<Kategorija>()
                .HasData
                (
                    new Kategorija { Id = 1, Naziv = "Predjelo", Opis = "Opis k1" },
                    new Kategorija { Id = 2, Naziv = "Glavno Jelo", Opis = "Opis k2" },
                    new Kategorija { Id = 3, Naziv = "Desert", Opis = "Opis k3" }
                );
            modelBuilder.Entity<Jelo>()
                .HasData
                (
                    new Jelo { Id = 1, KategorijaId = 1, Cijena = 5, Naziv = "Hamburger", Opis = "Opis za hamburger" }, //SLIKA
                    new Jelo { Id = 2, KategorijaId = 1, Cijena = 6, Naziv = "Cevapi", Opis = "Opis za Cevapi" }, 
                    new Jelo { Id = 3, KategorijaId = 2, Cijena = 4, Naziv = "Test", Opis = "Opis test" }
                );
            modelBuilder.Entity<Narudzba>()
                .HasData
                (
                    new Narudzba { Id = 1, DatumNarudzbe = DateTime.Now, KorisnikId = 1, StatusNarudzbeId = 1 }
                );
            modelBuilder.Entity<StavkeNarudzbe>()
                .HasData
                (
                    new StavkeNarudzbe { Id = 1, Cijena = 5, JeloId = 1, NarudzbaId = 1, Kolicina = 2 }
                );
            modelBuilder.Entity<StatusNarudzbe>()
                .HasData
                (
                    new StatusNarudzbe { Id = 1, Naziv = "Primljena" },
                    new StatusNarudzbe { Id = 2, Naziv = "U pripremi" }, 
                    new StatusNarudzbe { Id = 3, Naziv = "Isporucena" } 
                );
            modelBuilder.Entity<Korisnik>()
                .HasData
                (
                    new Korisnik { Id = 1, Ime = "Admin", KorisnickoIme = "admin", Prezime="admin", LozinkaSalt = salts[0], LozinkaHash = PasswordHelper.GenerateHash(salts[0], "admin") },
                    new Korisnik { Id = 2, Ime = "test", KorisnickoIme = "test", Prezime="test", LozinkaSalt = salts[1], LozinkaHash = PasswordHelper.GenerateHash(salts[1], "test") }
                );
            modelBuilder.Entity<Recenzija>()
                .HasData
                (
                    new Recenzija { Id = 1, JeloId = 1, KorisnikId = 1, Ocjena = 3, Opis = "abc123"},
                    new Recenzija { Id = 2, JeloId = 2, KorisnikId = 1, Ocjena = 3, Opis = "cba123"},
                    new Recenzija { Id = 3, JeloId = 1, KorisnikId = 2, Ocjena = 4, Opis = "def123"},
                    new Recenzija { Id = 4, JeloId = 2, KorisnikId = 2, Ocjena = 4, Opis = "fed123"}
                );
        }
    }
}
