using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eRestoran.WebAPI.Services
{
    public class UplataService : CRUDService<Model.Uplata, UplataSearchRequest, Database.Recenzija, UplataUpsertRequest, UplataUpsertRequest>
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;

        public UplataService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<Model.Uplata> Get(UplataSearchRequest search)
        {
            var query = _context.Uplata.AsQueryable();

            if (search.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Uplata>>(list);
        }
    }
}