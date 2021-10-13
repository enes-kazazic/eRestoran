using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebAPI.Services
{
	public interface IBaseService<T, TSearch>
	{
		List<T> Get(TSearch search);
		T GetById(int id);

	}
}
