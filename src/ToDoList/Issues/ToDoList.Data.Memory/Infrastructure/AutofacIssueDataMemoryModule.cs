using Autofac;
using ToDoList.Data.Memory.Repositories;
using ToDoList.Data.Repositories.CategoryRepository;
using ToDoList.Data.Repositories.IssueRepository;

namespace ToDoList.Data.Memory.Infrastructure
{
    public class AutofacIssueDataMemoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<IssueRepository>().As<IIssueRepository>();
        }
    }
}
