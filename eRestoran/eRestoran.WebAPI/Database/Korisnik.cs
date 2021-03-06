using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Database
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int GradId { get; set; }
        public int DrzavaId { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public virtual Uposlenik Uposlenik { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual Drzava Drzava { get; set; }

        public ICollection<Uplata> Uplate { get; set; }
    }
}
