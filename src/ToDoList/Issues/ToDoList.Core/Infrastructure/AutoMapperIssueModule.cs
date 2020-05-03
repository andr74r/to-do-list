using AutoMapper;
using ToDoList.Issue.Core.Dto;
using ToDoList.Issue.Data.Entities;

namespace ToDoList.Issue.Core.Infrastructure
{
    public static class AutoMapperIssueModule
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CategoryDto, Category>();
            cfg.CreateMap<Category, CategoryDto>();
            cfg.CreateMap<IssueDto, Data.Entities.Issue>();
            cfg.CreateMap<Data.Entities.Issue, IssueDto>();
        }
    }
}
