using eRestoran.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Services
{
    public interface IJeloService : ICRUDService<Model.Jelo, JeloSearchRequest, JeloUpsertRequest, JeloUpsertRequest>
    {
        List<Model.Jelo> GetPreporucenaJela(int korisnikId);
    }
}
