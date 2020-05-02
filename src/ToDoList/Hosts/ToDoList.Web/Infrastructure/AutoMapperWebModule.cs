using AutoMapper;
using ToDoList.Core.Dto;
using ToDoList.Security.Core.Dto;
using ToDoList.Web.ViewModels;
using ToDoList.Web.ViewModels.Account;

namespace ToDoList.Web.Infrastructure
{
    public static class AutoMapperWebModule
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CategoryDto, CategoryViewModel>();
            cfg.CreateMap<UpdateCategoryViewModel, CategoryDto>();
            cfg.CreateMap<IssueDto, IssueViewModel>();

            cfg.CreateMap<LoginViewModel, FindUserByPasswordDto>();
            cfg.CreateMap<RegisterViewModel, CreateUserDto>();
        }
    }
}
