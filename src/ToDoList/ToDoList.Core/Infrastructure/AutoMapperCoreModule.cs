using AutoMapper;
using ToDoList.Core.Dto;
using ToDoList.Data.Entities;

namespace ToDoList.Core.Infrastructure
{
    public static class AutoMapperCoreModule
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CategoryDto, Category>();
            cfg.CreateMap<Category, CategoryDto>();
            cfg.CreateMap<IssueDto, Issue>();
            cfg.CreateMap<Issue, IssueDto>();
        }
    }
}
