using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
	public class Jelo
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string Opis { get; set; }
		public int Cijena { get; set; }
		public int KategorijaId { get; set; }
	}
}
