using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Services
{
    public class KorisniciService : CRUDService<Model.Korisnik, KorisnikSearchRequest, Database.Korisnik, KorisnikUpsertRequest, KorisnikUpsertRequest>, IKorisniciService
    {
        public eRestoranContext Context { get; set; }
        protected readonly IMapper _mapper;

        public KorisniciService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public override List<Model.Korisnik> Get(KorisnikSearchRequest search)
        {
            var query = Context.Korisnik.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.ImePrezime))
            {
                query = query.Where(x => x.Ime.ToLower().Contains(search.ImePrezime) || x.Prezime.ToLower().Contains(search.ImePrezime));
            }

            var list = query.ToList();


            return _mapper.Map<List<Model.Korisnik>>(list);
        }

        public IList<Model.Korisnik> GetAll()
        {
            var db = Context.Korisnik.ToList();

            var result = _mapper.Map<IList<Model.Korisnik>>(db);

            return result;
        }

        public Model.Korisnik GetById(int id)
        {
            var entity = Context.Korisnik.Include(x => x.Uposlenik).FirstOrDefault(x => x.Id == id);

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public override async Task<Model.Korisnik> InsertAsync(KorisnikUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);

            entity.LozinkaSalt = PasswordHelper.GenerateSalt();
            entity.LozinkaHash = PasswordHelper.GenerateHash(entity.LozinkaSalt, request.Password);

            await Context.Database.BeginTransactionAsync();

            Context.Korisnik.Add(entity);
            await Context.SaveChangesAsync();

            var employee = new Uposlenik
            {
                UposlenikId = entity.Id,
                NazivPosla = request.NazivPosla,
                DatumZaposlenja = request.DatumZaposlenja,
            };

            Context.Uposlenik.Add(employee);
            await Context.SaveChangesAsync();
            await Context.Database.CommitTransactionAsync();

            return _mapper.Map<Model.Korisnik>(entity);

        }

        public override async Task<Model.Korisnik> UpdateAsync(int id, KorisnikUpsertRequest request)
        {
            var entity = Context.Korisnik.Find(id);

            await Context.Database.BeginTransactionAsync();
            _mapper.Map(request, entity);
            await Context.SaveChangesAsync();

            var zaposlenik = Context.Uposlenik.Find(id);
            if (zaposlenik != null)
            {
                zaposlenik.NazivPosla = request.NazivPosla;
                zaposlenik.DatumZaposlenja = request.DatumZaposlenja;
                await Context.SaveChangesAsync();
            }

            await Context.Database.CommitTransactionAsync();

            return _mapper.Map<Model.Korisnik>(entity);
        }
        public async Task<Model.Korisnik> Login(string username, string password)
        {
            var entity = await Context.Korisnik.FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                throw new UserException("Pogrešan username ili password");
            }

            var hash = PasswordHelper.GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                throw new UserException("Pogrešan username ili password");
            }

            return _mapper.Map<Model.Korisnik>(entity);
        }
    }
}


