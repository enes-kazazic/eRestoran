using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class CRUDController<T,TSearch,TInsert,TUpdate> : BaseController<T, TSearch>
	{
		private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;

		public CRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("InsertAll")]
		public Task<List<T>> InsertAll(List<TInsert> request)
		{
			return _service.InsertAsync(request);
		}

		[HttpPost]
		public T Insert(TInsert request)
		{
			return _service.Insert(request);
		}

		[HttpPut("{id}")]
		public T Update(int id, [FromBody]TUpdate request)
		{
			return _service.Update(id ,request);
		}

		[HttpDelete("{id}")]
		public bool Delete(int id)
		{
			return _service.Delete(id);
		}
	}
}
