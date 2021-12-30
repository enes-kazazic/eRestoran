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
	public class NarudzbaController : CRUDController<Model.Narudzba,NarudzbaSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest>
	{
		public NarudzbaController(ICRUDService<Narudzba, NarudzbaSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest> service) : base(service)
		{

		}
	}
}
