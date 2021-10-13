using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Services
{
	public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IBaseService<T, TSearch>
	{
		T Insert(TInsert request);
		T Update(int id, TUpdate request);
		bool Delete(int id);
	}
}
