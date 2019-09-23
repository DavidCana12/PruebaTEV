using PruebaTEV.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTEV.Core
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetUserId(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
