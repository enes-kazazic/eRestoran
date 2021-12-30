using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using StatusNarudzbe = eRestoran.Model.StatusNarudzbe;

namespace eRestoran.WebAPI.Services
{
	public class StatusNarudzbeService:BaseService<Model.StatusNarudzbe,StatusNarudzbeSearchRequest,Database.StatusNarudzbe>
	{
		private readonly eRestoranContext _context;
		private readonly IMapper _mapper;

		public StatusNarudzbeService(eRestoranContext context, IMapper mapper) : base(context, mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public override List<StatusNarudzbe> Get(StatusNarudzbeSearchRequest request)
		{
			var query = _context.StatusNarudzbe.AsQueryable();

			if (!string.IsNullOrWhiteSpace(request.Naziv))
			{
				query = query.Where(x => x.Naziv.Contains(request.Naziv));
			}

			var list = query.ToList();

			return _mapper.Map<List<StatusNarudzbe>>(list);
		}
	}
}
