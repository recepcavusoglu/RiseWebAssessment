using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData.Interfaces
{
    internal interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(int id);
    }
}
