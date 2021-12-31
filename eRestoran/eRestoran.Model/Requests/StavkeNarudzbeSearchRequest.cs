using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
	public class StavkeNarudzbeSearchRequest
	{
		public int JeloId { get; set; }
        public int NarudzbaId { get; set; }
        public int KorisnikId { get; set; }
    }
}
