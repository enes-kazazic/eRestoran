using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KategorijaController:BaseController<Model.Kategorija, KategorijaSearchRequest>
	{
		public KategorijaController(IBaseService<Kategorija, KategorijaSearchRequest> service) : base(service)
		{
		}
	}
}
