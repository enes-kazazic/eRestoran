using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Database
{
    public class Recenzija
    {
	    public int Id { get; set; }
	    public int Ocjena { get; set; }
	    public string Opis { get; set; }
	    public int KorisnikId { get; set; }
	    public Korisnik Korisnik { get; set; }
    }
}
