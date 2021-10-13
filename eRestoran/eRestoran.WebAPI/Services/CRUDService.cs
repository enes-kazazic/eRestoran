﻿using System;
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

		public virtual TModel Insert(TInsert request)
		{
			var entity = _mapper.Map<TDatabase>(request);

			_context.Set<TDatabase>().Add(entity);
			_context.SaveChanges();
			
			return _mapper.Map<TModel>(entity);
		}

		public virtual TModel Update(int id, TUpdate request)
		{
			var entity = _context.Set<TDatabase>().Find(id);
			_context.Set<TDatabase>().Attach(entity);
			_context.Set<TDatabase>().Update(entity);
			_mapper.Map(request, entity);

			_context.SaveChanges();
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
