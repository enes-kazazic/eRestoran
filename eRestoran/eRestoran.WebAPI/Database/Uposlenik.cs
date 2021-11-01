using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Database
{
	public class Uposlenik
	{
		[ForeignKey("Korisnik")]
		public int UposlenikId { get; set; }
		public DateTime DatumZaposlenja { get; set; }
		public string NazivPosla { get; set; }

		public virtual Korisnik Korisnik { get; set; }
	}
}
