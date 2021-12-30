	using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eRestoran.WebAPI.Services
{
	public class JeloService:CRUDService<Model.Jelo,JeloSearchRequest,Database.Jelo, JeloUpsertRequest, JeloUpsertRequest>
	{
		private readonly eRestoranContext _context;
		private readonly IMapper _mapper;
		public JeloService(eRestoranContext context, IMapper mapper) : base(context, mapper)
		{
			_context = context;
			_mapper = mapper;

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

			var list = query.ToList();

			return _mapper.Map<List<Model.Jelo>>(list);
		}
	}
}
