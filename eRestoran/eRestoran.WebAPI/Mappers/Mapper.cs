using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Services;

namespace eRestoran.WebAPI.Mappers
{
	public class Mapper:Profile
	{
		public Mapper()
		{
			CreateMap<Database.Jelo, Model.Jelo>()
				.ForMember(x => x.Kategorija, db => db.MapFrom(src => src.Kategorija.Naziv))
				.ReverseMap();
			CreateMap<JeloUpsertRequest, Database.Jelo>();

			CreateMap<Database.Kategorija, Model.Kategorija>();
			CreateMap<KategorijaSearchRequest, Model.Kategorija>();
			CreateMap<KategorijaUpsertRequest, Database.Kategorija>();
			
			CreateMap<Database.StatusNarudzbe, Model.StatusNarudzbe>();
			CreateMap<StatusNarudzbeSearchRequest, Model.StatusNarudzbe>();
			
			CreateMap<Database.Narudzba, Model.Narudzba>()
				.ForMember(x=>x.Korisnik, db=>db.MapFrom(src=>src.Korisnik.Ime + " " + src.Korisnik.Prezime))
				.ForMember(x=>x.StatusNarudzbe, db=>db.MapFrom(src=>src.StatusNarudzbe.Naziv));
			CreateMap<NarudzbaSearchRequest, Model.Narudzba>();
			CreateMap<NarudzbaUpsertRequest, Database.Narudzba>();

			CreateMap<Database.StavkeNarudzbe, Model.StavkeNarudzbe>();
			CreateMap<StavkeNarudzbeSearchRequest, Model.StavkeNarudzbe>();
			CreateMap<StavkeNarudzbeUpsertRequest, Database.StavkeNarudzbe>();
			CreateMap<List<StavkeNarudzbeUpsertRequest>, List<Database.StavkeNarudzbe>>();

			CreateMap<Database.Recenzija, Model.Recenzija>();
			CreateMap<RecenzijaUpsertRequest, Database.Recenzija>();

			CreateMap<Database.Korisnik, Model.Korisnik>()
				.ForMember(dest=>dest.ImePrezime, src=> src.MapFrom(x=>$"{x.Ime} {x.Prezime}"));
			CreateMap<Database.Uposlenik, Model.Uposlenik>();
			CreateMap<KorisnikUpsertRequest, Database.Korisnik>();

			CreateMap<Database.Grad, Model.Grad>();

			CreateMap<Database.Drzava, Model.Drzava>();

            CreateMap<Database.Uplata, Model.Uplata>();
        }
	}
}
