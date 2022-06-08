using AutoMapper;
using eRestoran.WebAPI.Database;

namespace eRestoran.WebAPI.Services
{
    public class DrzavaService : BaseService<Model.Drzava, object, Database.Drzava>
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;

        public DrzavaService(eRestoranContext context,
                             IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}