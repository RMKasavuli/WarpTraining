using Library.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Common
{
	public interface IPersonService 
	{
		List<Person> GetAll(int pageSize = 1000, int page = 0);
		
		Person GetById(int id);

		Person FindById(int id);

		
		void Insert(Person person);


		void Update(Person person);


		void Delete(Person person);

	}
}
