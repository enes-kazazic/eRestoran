using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Narudzba = eRestoran.Model.Narudzba;

namespace eRestoran.WebAPI.Services
{
    public class NarudzbaService : CRUDService<Model.Narudzba, NarudzbaSearchRequest, Database.Narudzba, NarudzbaUpsertRequest, NarudzbaUpsertRequest>
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        public NarudzbaService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
            _context =  context;
            _mapper = mapper;
        }

        public override Narudzba GetById(int id)
        {
            var result = _context.Narudzba.Include(x => x.Korisnik)
                                            .Include(x => x.StatusNarudzbe)
                                            .FirstOrDefault(x => x.Id == id);

            return _mapper.Map<Narudzba>(result);
        }

        public override List<Narudzba> Get(NarudzbaSearchRequest search)
        {
            var query = _context.Narudzba.AsQueryable();
            if(search.Id != 0)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (search.DatumNarudzbe != null)
            {
                query = query.Where(x => x.DatumNarudzbe.Date == search.DatumNarudzbe.Value.Date);
            }

            if (search.StatusNarudzbeId != 0)
            {
                query = query.Where(x => x.StatusNarudzbeId == search.StatusNarudzbeId);
            }

            if(search.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }

            var list = query.Include(x => x.Korisnik)
                            .Include(x => x.StatusNarudzbe)
                            .ToList();

            return _mapper.Map<List<Model.Narudzba>>(list);
        }

        public override Narudzba Update(int id, NarudzbaUpsertRequest request)
        {
            var entity = Context.Narudzba.Find(id);

            _context.Attach(request);

            entity.StatusNarudzbeId = request.StatusNarudzbeId;
            _context.SaveChanges();

            return base.Update(id, request);
        }
    }
}
