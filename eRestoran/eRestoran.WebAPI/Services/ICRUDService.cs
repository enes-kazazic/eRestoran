using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Services
{
	public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IBaseService<T, TSearch>
	{
		Task<List<T>> InsertAsync(List<TInsert> request);

		Task<T> InsertAsync(TInsert request);
		Task<T> UpdateAsync(int id, TUpdate request);
		bool Delete(int id);
	}
}
