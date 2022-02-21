using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
	public class JeloUpsertRequest
	{
		public string Naziv { get; set; }
		public string Opis { get; set; }
		public decimal Cijena { get; set; }
		public int KategorijaId { get; set; }
	}
}
