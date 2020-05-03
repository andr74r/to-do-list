using System.Linq;
using ToDoList.Security.Data.Entities;
using ToDoList.Security.Data.Repositories;

namespace ToDoList.Security.Data.Memory.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly object _syncObj = new object();
        private static int _currentId = 0;

        public void CreateUser(User user)
        {
            lock (_syncObj)
            {
                _currentId++;

                user.Id = _currentId;

                Context.Users.Add(user);
            }
        }

        public User FindUser(string email, string phone)
        {
            return Context.Users.SingleOrDefault(x => x.Email == email || x.Phone == phone);
        }
    }
}
