using Library.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Common
{
    public interface IGroupService
    {
        List<Group> GetAll(int pageSize = 1000, int page = 0);

        Group GetById(int id);

        Group FindById(int id);


        void Insert(Group group);


        void Update(Group group);


        void Delete(Group group);
    }
}
