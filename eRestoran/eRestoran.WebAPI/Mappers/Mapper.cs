﻿using System;
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
			CreateMap<Database.Jelo, Model.Jelo>();
			CreateMap<JeloUpsertRequest, Database.Jelo>();
			
			CreateMap<Database.Kategorija, Model.Kategorija>();
			CreateMap<KategorijaSearchRequest, Model.Kategorija>();
			
			CreateMap<Database.StatusNarudzbe, Model.StatusNarudzbe>();
			CreateMap<StatusNarudzbeSearchRequest, Model.StatusNarudzbe>();
			
			CreateMap<Database.Narudzba, Model.Narudzba>()
				.ForMember(x=>x.Korisnik, db=>db.MapFrom(src=>src.Korisnik.Ime + " " + src.Korisnik.Prezime))
				.ForMember(x=>x.StatusNarudzbe, db=>db.MapFrom(src=>src.StatusNarudzbe.Naziv));
			CreateMap<NarudzbaSearchRequest, Model.Narudzba>();

			CreateMap<Database.StavkeNarudzbe, Model.StavkeNarudzbe>();
			CreateMap<StavkeNarudzbeSearchRequest, Model.StavkeNarudzbe>();
			CreateMap<StavkeNarudzbeUpsertRequest, Database.StavkeNarudzbe>();

			
		}
	}
}
