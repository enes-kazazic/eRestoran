using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Services
{
    public class RecenzijaService : CRUDService<Model.Recenzija, object, Database.Recenzija, RecenzijaUpsertRequest, RecenzijaUpsertRequest>
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        public RecenzijaService(eRestoranContext context, IMapper mapper):base(context,mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
