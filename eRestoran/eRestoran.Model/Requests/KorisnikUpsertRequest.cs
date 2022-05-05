using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Model.Requests
{
    public class KorisnikUpsertRequest
    {
		public int Id { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }
	}
}
