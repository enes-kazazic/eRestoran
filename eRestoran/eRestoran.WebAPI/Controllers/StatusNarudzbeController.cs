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
	public class StatusNarudzbeController : BaseController<Model.StatusNarudzbe, StatusNarudzbeSearchRequest>
	{
		public StatusNarudzbeController(IBaseService<StatusNarudzbe, StatusNarudzbeSearchRequest> service) : base(service)
		{
		}
	}
}
