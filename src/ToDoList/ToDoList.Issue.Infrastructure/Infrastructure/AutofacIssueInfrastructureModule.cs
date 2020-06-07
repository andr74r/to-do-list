using Autofac;
using ToDoList.Issue.Domain.Repositories;
using ToDoList.Issue.Infrastructure.InMemory;

namespace ToDoList.Issue.Infrastructure.Infrastructure
{
    public class AutofacIssueInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryCategoryRepository>().As<ICategoryRepository>();
        }
    }
}
