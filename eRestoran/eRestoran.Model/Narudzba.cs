using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
	public class Narudzba
	{
		public int Id { get; set; }
		public DateTime DatumNarudzbe { get; set; }
		public int KorisnikId { get; set; }
		public string Korisnik { get; set; }
		public int StatusNarudzbeId { get; set; }
		public string StatusNarudzbe { get; set; }
	}
}
