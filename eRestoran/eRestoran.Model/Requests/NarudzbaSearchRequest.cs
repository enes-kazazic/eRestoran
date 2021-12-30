using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
	public class NarudzbaSearchRequest
	{
		public DateTime? DatumNarudzbe { get; set; }
		public int KorisnikId { get; set; }
		public int StatusNarudzbeId { get; set; }
	}
}
