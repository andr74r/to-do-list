using Autofac;
using ToDoList.Issue.Data.Memory.Repositories;
using ToDoList.Issue.Data.Repositories;

namespace ToDoList.Issue.Data.Memory.Infrastructure
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
