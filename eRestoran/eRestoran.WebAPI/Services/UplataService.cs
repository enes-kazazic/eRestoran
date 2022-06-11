using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Services
{
    public class UplataService : CRUDService<Model.Uplata, UplataSearchRequest, Database.Uplata, UplataUpsertRequest, UplataUpsertRequest>
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

        public override async Task<Model.Uplata> InsertAsync(UplataUpsertRequest request)
        {
            var uplata = new Uplata()
            {
                Iznos = request.Iznos,
                BrojTransakcije = request.BrojTransakcije,
                DatumTransakcije = DateTime.Parse(request.DatumTransakcije),
                KorisnikId = request.KorisnikId
            };

            await _context.Uplata.AddAsync(uplata);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Uplata>(uplata);
        }
    }
}