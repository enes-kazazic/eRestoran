using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace eRestoran.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JeloController : CRUDController<Model.Jelo,JeloSearchRequest, JeloUpsertRequest, JeloUpsertRequest>
	{
		protected new readonly IJeloService _service;

		public JeloController(IJeloService service) : base(service)
		{
			_service = service;
		}

		[Authorize]
		[HttpGet("preporuceno/{korisnikId}")]
		public List<Model.Jelo> GetPreporucenaJela(int korisnikId)
		{
			return _service.GetPreporucenaJela(korisnikId);
		}
	}
}
