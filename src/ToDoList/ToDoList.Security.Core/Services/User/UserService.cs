using ToDoList.Security.Core.Dto;
using ToDoList.Security.Data.Repositories;

namespace ToDoList.Security.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = null;
        }

        public UserDto CreateUser(UserDto userDto)
        {
            throw new System.NotImplementedException();
        }

        public UserDto FindUser(FindUserByPasswordDto request)
        {
            throw new System.NotImplementedException();
        }

        public UserDto FindUser(FindUserDto request)
        {
            throw new System.NotImplementedException();
        }
    }
}
