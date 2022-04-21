using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using Microsoft.AspNetCore.Mvc;
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
            
            if (search.NarudzbaId != 0)
            {
                query = query.Where(x => x.NarudzbaId == search.NarudzbaId);
            }
            if (search.KorisnikId!= 0)
            {
                query = query.Where(x => x.Narudzba.KorisnikId == search.KorisnikId);
            }
            if (search.JeloId != 0)
            {
                query = query.Where(x => x.JeloId == search.JeloId);
            }
            var list = query.Include(x=>x.Jelo).ToList();

            var result = _mapper.Map<List<Model.StavkeNarudzbe>>(list);
            return result;
        }

        [HttpPost]
        public override async Task<List<Model.StavkeNarudzbe>> InsertAsync(List<StavkeNarudzbeUpsertRequest> request)
        {
            var result = request.Select(i => new StavkeNarudzbe
            {
                JeloId = i.Jelo.Id,
                //Cijena = int.Parse(i.Jelo.Cijena.ToString()),
                Kolicina = i.Kolicina,
                NarudzbaId = i.NarudzbaId,
            }).ToList();

            await _context.StavkeNarudzbe.AddRangeAsync(result);
            await _context.SaveChangesAsync();

            var model = result.Select(i => new Model.StavkeNarudzbe
            {
                Id = i.Id,
                NarudzbaId = i.NarudzbaId,
                JeloId = i.JeloId,
                Kolicina = i.Kolicina,
                Cijena = i.Cijena,
            }).ToList();

            return model;
        }
    }
}
