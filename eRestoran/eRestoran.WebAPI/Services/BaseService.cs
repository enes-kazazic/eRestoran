using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.WebAPI.Database;

namespace eRestoran.WebAPI.Services
{
	public class BaseService<TModel, TSearch, TDatabase> : IBaseService<TModel, TSearch> where TDatabase : class
	{
		protected readonly eRestoranContext Context;
		protected readonly IMapper _mapper;

		public BaseService(eRestoranContext context, IMapper mapper)
		{
			Context = context;
			mapper = _mapper;
		}
		public virtual List<TModel> Get(TSearch search)
		{
			var list = Context.Set<TDatabase>().ToList();

			return _mapper.Map<List<TModel>>(list);
		}

		public virtual TModel GetById(int id)
		{
			var entity = Context.Set<TDatabase>().Find(id);

			return _mapper.Map<TModel>(entity);
		}
	}
}
