using PruebaTEV.Class;
using PruebaTEV.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTEV.Core
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext userContext)
        {
            _dbContext = userContext;
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            _dbContext.Users.Remove(new User { id = id });
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetUser()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserId(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void UpdateUser(User user)
        {
            var origen = _dbContext.Users.Find(user.id);

            origen.id = user.id;
            origen.LastName = user.LastName;
            origen.Name = user.Name;
            origen.UpdateDate = user.UpdateDate;
            origen.Address = user.Address;
            origen.CreateDate = user.CreateDate;

            _dbContext.Users.Update(origen);

        }
    }
}
