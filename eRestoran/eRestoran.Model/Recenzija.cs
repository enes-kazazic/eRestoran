using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class Recenzija
    {
        public int Id { get; set; }
        public int Ocjena { get; set; }
        public string Opis { get; set; }
        public int JeloId { get; set; }
        //public int KorisnikId { get; set; }
    }
}
