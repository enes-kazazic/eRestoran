using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

namespace eRestoran.WebAPI.Services
{
	public class JeloService:CRUDService<Model.Jelo,JeloSearchRequest,Database.Jelo, JeloUpsertRequest, JeloUpsertRequest>, IJeloService
	{
		private readonly eRestoranContext _context;
		private readonly IMapper _mapper;
		static MLContext _mLContext;
		public JeloService(eRestoranContext context, IMapper mapper) : base(context, mapper)
		{
			_context = context;
			_mapper = mapper;

		}

		public List<Model.Jelo>	GetPreporucenaJela(int korisnikId)
        {
			var korisnici = Context.Korisnik.Where(e => e.Id != korisnikId).ToList();

			Dictionary<Database.Korisnik, List<Database.Recenzija>> recenzije = new Dictionary<Database.Korisnik, List<Database.Recenzija>>();
			foreach (var korisnik in korisnici)
			{
				var ocjene = Context.Recenzija
					.Where(e => e.KorisnikId == korisnik.Id)
					.ToList();
				recenzije.Add(korisnik, ocjene);
			}

			var recenzijeKorisnik = Context.Recenzija.Where(e => e.KorisnikId == korisnikId).ToList();

			if (recenzijeKorisnik == null || recenzijeKorisnik.Count == 0)
				return null;

			List<Database.Recenzija> zajednickeOcjeneKorisnik = new List<Database.Recenzija>();
			List<Database.Recenzija> zajednickeOcjeneKorisnik2 = new List<Database.Recenzija>();

			var preporucenaJelaIds = new List<int>();

			foreach (var item in recenzije)
			{
				foreach (var recenzija in recenzijeKorisnik)
				{
					if (item.Value.Any(x => x.JeloId == recenzija.JeloId))
					{
						zajednickeOcjeneKorisnik.Add(recenzija);
						zajednickeOcjeneKorisnik2.Add(item.Value.FirstOrDefault(e => e.JeloId == recenzija.JeloId));
					}
				}

				double slicnost = GetSlicnost(zajednickeOcjeneKorisnik, zajednickeOcjeneKorisnik2);

				if (slicnost > 0.5)
				{
					var dobroOcjenjenaJelaIds = recenzije
						.Select(e => e.Value)
						.SelectMany(e => e)
						.Where(e => e.Ocjena > 3)
						.Select(e => e.JeloId)
						.Where(e => !preporucenaJelaIds.Contains(e))
						.ToList();

					dobroOcjenjenaJelaIds.ForEach(e => {
						if (!preporucenaJelaIds.Contains(e))
							preporucenaJelaIds.Add(e);
					});
				}

				zajednickeOcjeneKorisnik.Clear();
				zajednickeOcjeneKorisnik2.Clear();
			}

			var preporucenaJela = Context.Set<Database.Jelo>()
				.Where(x=> preporucenaJelaIds.Contains(x.Id))
				.ToList();

			var result = _mapper.Map<List<Model.Jelo>>(preporucenaJela);
			return result;
		}

		private double GetSlicnost(List<Database.Recenzija> zajednickeOcjene1, List<Database.Recenzija> zajednickeOcjene2)
		{
			if (zajednickeOcjene1.Count != zajednickeOcjene2.Count)
				return 0;

			double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

			for (int i = 0; i < zajednickeOcjene1.Count; i++)
			{
				brojnik += zajednickeOcjene1[i].Ocjena * zajednickeOcjene2[i].Ocjena;
				nazivnik1 += zajednickeOcjene1[i].Ocjena * zajednickeOcjene1[i].Ocjena;
				nazivnik2 += zajednickeOcjene2[i].Ocjena * zajednickeOcjene2[i].Ocjena;
			}
			nazivnik1 = Math.Sqrt(nazivnik1);
			nazivnik2 = Math.Sqrt(nazivnik2);

			double nazivnik = nazivnik1 * nazivnik2;
			if (nazivnik == 0)
				return 0;
			else
				return brojnik / nazivnik;
		}

		public override Model.Jelo GetById(int id)
        {
			var jelo = _context.Jelo.Where(x => x.Id == id)
									.Include(x => x.Kategorija);	
            return base.GetById(id);
        }

        public override List<Model.Jelo> Get(JeloSearchRequest request)
		{
			var query = _context.Jelo.AsQueryable();

			if (request.KategorijaId != 0)
			{
				query = query.Where(x => x.KategorijaId == request.KategorijaId);
			}

			if (!string.IsNullOrWhiteSpace(request.Naziv))
			{
				query = query.Where(x => x.Naziv.Contains(request.Naziv));
			}

			var list = query.Include(x=>x.Kategorija).ToList();

			return _mapper.Map<List<Model.Jelo>>(list);
		}
	}
}
