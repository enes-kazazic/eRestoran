using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.WebAPI.Services;

namespace eRestoran.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController<T,TSearch> : ControllerBase
	{
		private readonly IBaseService<T, TSearch> _service;

		public BaseController(IBaseService<T, TSearch> service)
		{
			_service = service;
		}

		[HttpGet]
		public List<T> Get([FromQuery] TSearch search)
		{
			return _service.Get(search);
		}

		[HttpGet("{id}")]
		public T GetById(int id)
		{
			return _service.GetById(id);
		}
	}
}
