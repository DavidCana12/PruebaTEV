using PruebaTEV.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTEV.Implementation
{
    public interface IUserManager
    {
        void Add(User user);
        void Update(User user);
        void Delete(int Id);

        User GetById(int Id);
        IEnumerable<User> GetList();
    }
}
