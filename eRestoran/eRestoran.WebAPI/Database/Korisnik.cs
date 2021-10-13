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
		public string Prezime{ get; set; }
		public string KorisnickoIme{ get; set; }
		public string LozinkaHash{ get; set; }
		public string LozinkaSalt{ get; set; }
		
	}
}
