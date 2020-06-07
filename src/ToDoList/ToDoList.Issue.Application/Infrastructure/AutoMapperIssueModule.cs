using AutoMapper;
using ToDoList.Issue.Core.Dto;
using ToDoList.Issue.Domain.Entities;

namespace ToDoList.Issue.Core.Infrastructure
{
    public static class AutoMapperIssueModule
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CategoryDto, Category>();
            cfg.CreateMap<Category, CategoryDto>();
            cfg.CreateMap<IssueDto, Domain.Entities.Issue>();
            cfg.CreateMap<Domain.Entities.Issue, IssueDto>();
        }
    }
}
