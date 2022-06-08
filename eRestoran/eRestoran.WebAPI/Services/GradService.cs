using AutoMapper;
using eRestoran.WebAPI.Database;

namespace eRestoran.WebAPI.Services
{
    public class GradService : BaseService<Model.Grad, object, Database.Grad>
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;

        public GradService(eRestoranContext context,
                             IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}