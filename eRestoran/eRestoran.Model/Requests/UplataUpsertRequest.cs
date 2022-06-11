using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Model.Requests
{
    public class UplataUpsertRequest
    {
        public double Iznos { get; set; }
        public string DatumTransakcije { get; set; }
        public string BrojTransakcije { get; set; }
        public int KorisnikId { get; set; }
    }
}
