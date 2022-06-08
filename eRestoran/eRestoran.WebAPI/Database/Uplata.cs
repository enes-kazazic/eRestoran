using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Database
{
    public class Uplata
    {
        public int Id { get; set; }
        public double Iznos { get; set; }
        public DateTime DatumTransakcije { get; set; }
        public string BrojTransakcije { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
