using eRestoran.Model.Requests;
using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplataController : CRUDController<Model.Uplata, UplataSearchRequest, UplataUpsertRequest, UplataUpsertRequest>
    {
        public UplataController(ICRUDService<Model.Uplata, UplataSearchRequest, UplataUpsertRequest, UplataUpsertRequest> service) : base(service)
        {
        }
    }
}