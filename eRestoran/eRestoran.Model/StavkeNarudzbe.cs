using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class StavkeNarudzbe 
    {
		public int Id { get; set; }
		public int Kolicina { get; set; }
		public int Cijena { get; set; }

		public int JeloId { get; set; }
		public Jelo Jelo { get; set; }

		public int NarudzbaId { get; set; }
	}
}
