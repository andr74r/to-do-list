using ToDoList.Security.Data.Entities;

namespace ToDoList.Security.Data.Repositories
{
    public interface IUserRepository
    {
        User FindUser(string email, string phone);

        User CreateUser(User user);
    }
}
