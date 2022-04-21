using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
	public class Jelo
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public byte[] Slika { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
		public int KategorijaId { get; set; }
        public string Kategorija { get; set; }

    }
}
