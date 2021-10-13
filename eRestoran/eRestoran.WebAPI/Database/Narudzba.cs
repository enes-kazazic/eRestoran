using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Database
{
	public class Narudzba
	{
		public int Id { get; set; }
		public DateTime DatumNarudzbe { get; set; }

		public int KorisnikId { get; set; }
		public Korisnik Korisnik { get; set; }

		public int StatusNarudzbeId { get; set; }
		public StatusNarudzbe StatusNarudzbe { get; set; }

	}
}
