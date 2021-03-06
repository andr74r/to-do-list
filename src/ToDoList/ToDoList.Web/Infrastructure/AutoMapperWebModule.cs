﻿using AutoMapper;
using ToDoList.Issue.Core.Dto;
using ToDoList.Security.Core.Dto;
using ToDoList.Web.ViewModels.Account;
using ToDoList.Web.ViewModels.Category;
using ToDoList.Web.ViewModels.Issue;

namespace ToDoList.Web.Infrastructure
{
    public static class AutoMapperWebModule
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CategoryDto, CategoryViewModel>();
            cfg.CreateMap<UpdateCategoryViewModel, CategoryDto>();
            cfg.CreateMap<IssueDto, IssueViewModel>();

            cfg.CreateMap<LoginViewModel, FindUserByPasswordDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Login));

            cfg.CreateMap<RegisterViewModel, CreateUserDto>();
            cfg.CreateMap<RegisterViewModel, FindUserDto>();
            cfg.CreateMap<UserDto, UserViewModel>();
        }
    }
}
