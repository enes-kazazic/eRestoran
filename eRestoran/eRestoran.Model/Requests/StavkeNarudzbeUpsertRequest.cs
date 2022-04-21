using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class StavkeNarudzbeUpsertRequest
    {
        public int Kolicina { get; set; }
        public int Cijena { get; set; }
        public int JeloId { get; set; }
        public Jelo Jelo { get; set; }
        public int NarudzbaId { get; set; }

        //public List<StavkeNarudzbe> stavkeNarudzbe { get; set; }
	}
}
