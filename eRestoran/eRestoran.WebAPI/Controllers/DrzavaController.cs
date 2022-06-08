using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrzavaController : BaseController<Model.Drzava, object>
    {
        public DrzavaController(IBaseService<Model.Drzava, object> service) : base(service)
        {
        }
    }
}