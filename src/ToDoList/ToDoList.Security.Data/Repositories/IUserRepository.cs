using ToDoList.Security.Data.Entities;

namespace ToDoList.Security.Data.Repositories
{
    public interface IUserRepository
    {
        User FindUser(string email, string phone);

        void CreateUser(User user);
    }
}
