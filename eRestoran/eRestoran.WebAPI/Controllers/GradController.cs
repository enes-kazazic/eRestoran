using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradController : BaseController<Model.Grad, object>
    {
        public GradController(IBaseService<Model.Grad, object> service) : base(service)
        {
        }
    }
}