using System;

namespace eRestoran.Model.Requests
{
    public class KorisnikUpsertRequest
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string NazivPosla { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public int DrzavaId { get; set; }
        public int GradId { get; set; }
    }
}