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
    public class GroupService: IGroupService
    {
        protected const String KEY_GETALL = "WarpTraining.Group.GetAll()";
        protected const String KEY_GETBYID = "WarpTraining.Group.GetById({0})";
        protected const String PATTERN = "WarpTraining.Group";

        IDataRepository<Group> _groupRepo;
        IDataRepository<Member> _memberRepo;
        ICacheManager _cacheManager;

        public GroupService(IDataRepository<Group> groupRepo, ICacheManager cacheManager,
            IDataRepository<Member> memberRepo)
        {
            _groupRepo = groupRepo;
            _cacheManager = cacheManager;
            _memberRepo = memberRepo;
        }


        public List<Data.Models.Common.Group> GetAll(int pageSize = 1000, int page = 0)
        {
            return _cacheManager.Get<List<Data.Models.Common.Group>>(KEY_GETALL, 10, () =>
            {
                return _groupRepo.Table.OrderBy(p => p.Name).Skip(page * pageSize).Take(pageSize).ToList();
            });
        }

        public Data.Models.Common.Group GetById(int id)
        {
            String key = String.Format(KEY_GETBYID, id);
            return _groupRepo.Table.FirstOrDefault(p => p.GroupId == id);
        
        }

        public Data.Models.Common.Group FindById(int id)
        {
            String key = String.Format(KEY_GETBYID, id);
            return _groupRepo.GetById(id);
          
        }

        public void Insert(Group group)
        {
            _groupRepo.Insert(group);
            _cacheManager.RemoveByPattern(PATTERN);
        }

        public void Update(Group group)
        {
            _groupRepo.Update(group);
            _cacheManager.RemoveByPattern(PATTERN);
        }

        public void Delete(Group group)
        {
            _groupRepo.Delete(group);
            _cacheManager.RemoveByPattern(PATTERN);
        }
    }
}
