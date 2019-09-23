using PruebaTEV.Class;
using PruebaTEV.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PruebaTEV.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _userRepository.CreateUser(user);

                transaction.Complete();
            }
        }

        public void Delete(int Id)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _userRepository.DeleteUser(Id);
                transaction.Complete();
            }
        }

        public User GetById(int Id)
        {
            return _userRepository.GetUserId(Id);
        }

        public IEnumerable<User> GetList()
        {
            return _userRepository.GetUser();
        }

        public void Update(User user)
        {
            var original = _userRepository.GetUserId(user.id);
            if (original == null)
            {
                throw new Exception(string.Format("Error ID: {0}", user.id));
            }

            if (original.Equals(user))
            {
                return;
            }

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _userRepository.UpdateUser(user);
                transaction.Complete();
            }
        }
    }
}
