using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Services;

namespace eRestoran.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JeloController : CRUDController<Model.Jelo,JeloSearchRequest, JeloUpsertRequest, JeloUpsertRequest>
	{
		public JeloController(ICRUDService<Jelo, JeloSearchRequest, JeloUpsertRequest, JeloUpsertRequest> service) : base(service)
		{
		}
	}
}
