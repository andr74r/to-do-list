using ToDoList.Security.Core.Dto;

namespace ToDoList.Security.Core.Services.User
{
    public interface IUserService
    {
        UserDto FindUser(FindUserByPasswordDto request);

        UserDto FindUser(FindUserDto request);

        UserDto CreateUser(UserDto userDto);
    }
}
