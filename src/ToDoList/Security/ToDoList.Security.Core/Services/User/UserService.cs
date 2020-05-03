using AutoMapper;
using System;
using ToDoList.Common;
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
        private readonly IEntityValidator<Data.Entities.User> _validator;

        public UserService(
            IUserRepository userRepository, 
            IHashProvider hashProvider,
            IMapper mapper,
            IEntityValidator<Data.Entities.User> validator)
        {
            _userRepository = userRepository;
            _hashProvider = hashProvider;
            _mapper = mapper;
            _validator = validator;
        }

        public UserService()
        {
            _userRepository = null;
        }

        public UserDto CreateUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<Data.Entities.User>(userDto);

            user.PasswordHash = _hashProvider.GetHash(userDto.Password);

            if (!_validator.IsValid(user))
            {
                throw new ArgumentException("User is invalid");
            }

            _userRepository.CreateUser(user);

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
