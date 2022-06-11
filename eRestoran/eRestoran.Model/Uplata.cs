using System;

namespace eRestoran.Model
{
    public class Uplata
    {
        public int Id { get; set; }
        public double Iznos { get; set; }
        public string BrojTransakcije { get; set; }
        public DateTime DatumTransakcije { get; set; }
        public int KorisnikId { get; set; }
    }
}