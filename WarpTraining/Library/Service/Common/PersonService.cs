using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Models.Common;
using Library.Services.Cache;

namespace Library.Service.Common
{
	public class PersonService : IPersonService
	{
		protected const String KEY_GETALL = "WarpTraining.Person.GetAll()";
		protected const String KEY_GETBYID = "WarpTraining.Person.GetById({0})";
		protected const String PATTERN = "WarpTraining.Person";

		IDataRepository<Person> _personRepo;
		IDataRepository<Member> _memberRepo;
		ICacheManager _cacheManager;

		public PersonService(IDataRepository<Person> personRepo, ICacheManager cacheManager,
			IDataRepository<Member> memberRepo)
		{
			_personRepo = personRepo;
			_cacheManager = cacheManager;
			_memberRepo = memberRepo;
		}


		public List<Data.Models.Common.Person> GetAll(int pageSize = 1000, int page=0)
		{
			return _cacheManager.Get<List<Data.Models.Common.Person>>(KEY_GETALL, 10, () =>
			{
				//return _personRepo.Table.OrderBy(p=> p.Email).Skip(page*pageSize).Take(pageSize).ToList();
                return _personRepo.Table.OrderBy(p => p.Name).Skip(page * pageSize).Take(pageSize).ToList();
            });
		}

		public Data.Models.Common.Person GetById(int id)
		{
			String key = String.Format(KEY_GETBYID, id);

			//return _cacheManager.Get<Data.Models.Common.Person>(key, 10, () =>
			//{
				return _personRepo.Table.FirstOrDefault(p=>p.PersonId == id);
			//});
		}

		public Data.Models.Common.Person FindById(int id)
		{
			String key = String.Format(KEY_GETBYID, id);

			//return _cacheManager.Get<Data.Models.Common.Person>(key, 10, () =>
			//{
				return _personRepo.GetById(id);
			//});
		}

		public void Insert(Person person)
		{
			_personRepo.Insert(person);
			_cacheManager.RemoveByPattern(PATTERN);
		}

		public void Update(Person person)
		{
			_personRepo.Update(person);
			_cacheManager.RemoveByPattern(PATTERN);
		}

		public void Delete(Person person)
		{
			_personRepo.Delete(person);
			_cacheManager.RemoveByPattern(PATTERN);
		}
	}
}
