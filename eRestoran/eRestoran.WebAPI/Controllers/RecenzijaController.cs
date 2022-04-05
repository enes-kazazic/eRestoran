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
	public class RecenzijaController : CRUDController<Model.Recenzija, object, RecenzijaUpsertRequest, RecenzijaUpsertRequest>
	{
		public RecenzijaController(ICRUDService<Recenzija, object, RecenzijaUpsertRequest, RecenzijaUpsertRequest> service) : base(service)
		{

		}
	}
}
