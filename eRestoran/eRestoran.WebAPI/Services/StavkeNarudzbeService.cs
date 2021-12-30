using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Services
{
    public class StavkeNarudzbeService : CRUDService<Model.StavkeNarudzbe, StavkeNarudzbeSearchRequest, Database.StavkeNarudzbe, StavkeNarudzbeUpsertRequest, StavkeNarudzbeUpsertRequest>
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;

        public StavkeNarudzbeService(IMapper mapper, eRestoranContext context):base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public override List<Model.StavkeNarudzbe> Get(StavkeNarudzbeSearchRequest search)
        {
            var query = _context.StavkeNarudzbe.AsQueryable();
            
            if (search.JeloId != 0)
            {
                query = query.Where(x => x.JeloId == search.JeloId);
            }

            var list = query.Include(x=>x.Jelo).ToList();

            var result = _mapper.Map<List<Model.StavkeNarudzbe>>(list);
            return result;
        }
    }
}
