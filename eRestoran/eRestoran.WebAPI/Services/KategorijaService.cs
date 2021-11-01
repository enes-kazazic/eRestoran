using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using Kategorija = eRestoran.Model.Kategorija;

namespace eRestoran.WebAPI.Services
{
	public class KategorijaService:BaseService<Model.Kategorija, KategorijaSearchRequest, Database.Kategorija>
	{
		private readonly eRestoranContext _context;
		private readonly IMapper _mapper;

		public KategorijaService(eRestoranContext context, IMapper mapper) : base(context, mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public override List<Kategorija> Get(KategorijaSearchRequest request)
		{
			var query = _context.Kategorija.AsQueryable();

			if (!string.IsNullOrWhiteSpace(request.Naziv))
			{
				query = query.Where(x => x.Naziv.Contains(request.Naziv));
			}

			var list = query.ToList();

			return _mapper.Map<List<Kategorija>>(list);
		}
	}
}
