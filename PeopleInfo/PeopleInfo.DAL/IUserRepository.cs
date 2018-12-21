using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleInfo.DAL
{
    public interface IUserRepository : IRepository<User>
    {
        void SaveChanges();
        
    }
}
