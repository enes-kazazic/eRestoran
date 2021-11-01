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
			CreateMap<Database.Jelo, Model.Jelo>();
			CreateMap<JeloUpsertRequest, Database.Jelo>();
			
			CreateMap<Database.Kategorija, Model.Kategorija>();
			CreateMap<KategorijaSearchRequest, Model.Kategorija>();

			
		}
	}
}
