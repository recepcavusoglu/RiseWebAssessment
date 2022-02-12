using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Interfaces;
using UserData.Models;

namespace UserData.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
