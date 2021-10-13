using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Database
{
	public class StavkeNarudzbe
	{
		public int Id { get; set; }
		public int Kolicina { get; set; }
		public int Cijena { get; set; }

		public int JeloId { get; set; }
		public Jelo Jelo { get; set; }

		public int NarudzbaId { get; set; }
		public Narudzba Narudzba { get; set; }
	}
}
