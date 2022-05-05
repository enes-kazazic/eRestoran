using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KorisnikController : CRUDController<Model.Korisnik, KorisnikSearchRequest, KorisnikUpsertRequest, KorisnikUpsertRequest>
	{
		protected readonly IKorisniciService _service;
		public KorisnikController(IKorisniciService service) : base(service)
		{
			_service = service;
		}

		[HttpGet("Authenticate")]
		[AllowAnonymous]
		public async Task<Model.Korisnik> Authenticate()
		{
			string authorization = HttpContext.Request.Headers["Authorization"];

			string encodedHeader = authorization["Basic ".Length..].Trim();

			Encoding encoding = Encoding.GetEncoding("iso-8859-1");
			string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedHeader));

			int seperatorIndex = usernamePassword.IndexOf(':');

			return await _service.Login(usernamePassword.Substring(0, seperatorIndex), usernamePassword[(seperatorIndex + 1)..]);
		}
	}
}
