using AutoMapper;
using ToDoList.Security.Core.Dto;
using ToDoList.Security.Data.Entities;

namespace ToDoList.Security.Core.Infrastructure
{
    public class AutoMapperSecurityCoreModule
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<UserDto, User>();
            cfg.CreateMap<CreateUserDto, User>();
        }
    }
}
