using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.WebAPI.Database;

namespace eRestoran.WebAPI.Services
{
	public class CRUDService<TModel, TSearch, TDatabase,TInsert, TUpdate> : 
		BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate>
		where TDatabase : class

	{
		private readonly eRestoranContext _context;
		private readonly IMapper _mapper;

		public CRUDService(eRestoranContext context, IMapper mapper) : base(context, mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async virtual Task<TModel> InsertAsync(TInsert request)
		{
			var entity = _mapper.Map<TDatabase>(request);

			await _context.Set<TDatabase>().AddAsync(entity);
			await _context.SaveChangesAsync();
			
			return _mapper.Map<TModel>(entity);
		}

		public async virtual Task<List<TModel>> InsertAsync(List<TInsert> request)
		{
			var entity = _mapper.Map<List<TInsert>, List<TDatabase>>(request);

			await _context.Set<TDatabase>().AddRangeAsync(entity);
			await _context.SaveChangesAsync();

			return _mapper.Map<List<TModel>>(entity);
		}

		public async virtual Task<TModel> UpdateAsync(int id, TUpdate request)
		{
			var entity = _context.Set<TDatabase>().Find(id);
			_context.Set<TDatabase>().Attach(entity);
			_context.Set<TDatabase>().Update(entity);
			_mapper.Map(request, entity);

			await _context.SaveChangesAsync();
			return _mapper.Map<TModel>(entity);
		}

		public virtual bool Delete(int id)
		{
			var entity = _context.Set<TDatabase>().Find(id);
			try
			{
				_context.Set<TDatabase>().Remove(entity);
				_context.SaveChanges();

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
