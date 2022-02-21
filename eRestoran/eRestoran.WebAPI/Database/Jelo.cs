using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Database
{
	public class Jelo
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string Opis { get; set; }
		public decimal Cijena { get; set; }

		public int KategorijaId { get; set; }
		public Kategorija Kategorija { get; set; }
	}
}
