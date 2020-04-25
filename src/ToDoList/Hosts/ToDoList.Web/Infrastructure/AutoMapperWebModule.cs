using AutoMapper;
using ToDoList.Core.Dto;
using ToDoList.Web.ViewModels;

namespace ToDoList.Web.Infrastructure
{
    public static class AutoMapperWebModule
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CategoryDto, CategoryViewModel>();
            cfg.CreateMap<UpdateCategoryViewModel, CategoryDto>();
        }
    }
}
