using Autofac;
using ToDoList.Core.Services.Category;
using ToDoList.Core.Services.Issue;

namespace ToDoList.Core.Infrastructure
{
    public class AutofacCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<IssueService>().As<IIssueService>();
        }
    }
}
