using Autofac;
using AutoMapper;
using ToDoList.Core.Dto;
using ToDoList.Core.Services.Category;
using ToDoList.Core.Services.Issue;
using ToDoList.Data.Entities;
using ToDoList.Data.Memory.Repositories;
using ToDoList.Data.Repositories.CategoryRepository;
using ToDoList.Data.Repositories.IssueRepository;

namespace ToDoList.Console
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<IssueRepository>().As<IIssueRepository>();

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<IssueService>().As<IIssueService>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<IssueDto, Issue>();
                cfg.CreateMap<Issue, IssueDto>();
            });


            builder.Register(ctx => new Mapper(configuration))
                .As<IMapper>();

            return builder.Build();
        }
    }
}
