using AutoMapper;
using ToDoList.Security.Core.Dto;
using ToDoList.Security.Core.Services.Hash;
using ToDoList.Security.Data.Repositories;

namespace ToDoList.Security.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashProvider _hashProvider;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository, 
            IHashProvider hashProvider,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _hashProvider = hashProvider;
            _mapper = mapper;
        }

        public UserService()
        {
            _userRepository = null;
        }

        public UserDto CreateUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<Data.Entities.User>(userDto);

            user.PasswordHash = _hashProvider.GetHash(userDto.Password);

            return _mapper.Map<UserDto>(user);
        }

        public UserDto FindUser(FindUserByPasswordDto request)
        {
            var user = _userRepository.FindUser(request.Email, request.Phone);

            if (user == null)
            {
                return null;
            }

            if (_hashProvider.GetHash(request.Password) != user.PasswordHash)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public UserDto FindUser(FindUserDto request)
        {
            var user = _userRepository.FindUser(request.Email, request.Phone);

            return _mapper.Map<UserDto>(user);
        }
    }
}
