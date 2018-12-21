using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleInfo.DAL
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
            :base(context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
