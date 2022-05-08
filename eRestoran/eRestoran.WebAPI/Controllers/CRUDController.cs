using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
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
		public async Task<T> InsertAsync(TInsert request)
		{
			return await _service.InsertAsync(request);
		}

		[HttpPut("{id}")]
		public async Task<T> UpdateAsync(int id, [FromBody]TUpdate request)
		{
			return await _service.UpdateAsync(id ,request);
		}

		[HttpDelete("{id}")]
		public bool Delete(int id)
		{
			return _service.Delete(id);
		}
	}
}
