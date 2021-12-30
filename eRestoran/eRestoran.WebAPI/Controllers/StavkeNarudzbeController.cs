using eRestoran.Model.Requests;
using eRestoran.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StavkeNarudzbeController : CRUDController<Model.StavkeNarudzbe,StavkeNarudzbeSearchRequest, StavkeNarudzbeUpsertRequest, StavkeNarudzbeUpsertRequest>
    {
        public StavkeNarudzbeController(ICRUDService<Model.StavkeNarudzbe, StavkeNarudzbeSearchRequest, StavkeNarudzbeUpsertRequest, StavkeNarudzbeUpsertRequest> service)
            :base(service)
        {

        }
    }
}
