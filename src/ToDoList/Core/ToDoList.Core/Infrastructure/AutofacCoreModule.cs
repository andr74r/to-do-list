using Autofac;
using ToDoList.Common;
using ToDoList.Core.Services.Category;
using ToDoList.Core.Services.DefaultCategoryCreator;
using ToDoList.Core.Services.Issue;
using ToDoList.Core.Validators;
using ToDoList.Data.Entities;

namespace ToDoList.Core.Infrastructure
{
    public class AutofacCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<IssueService>().As<IIssueService>();
            builder.RegisterType<DefaultCategoryCreator>().As<IDefaultCategoryCreator>();
            builder.RegisterType<IssueValidator>().As<IEntityValidator<Issue>>();
            builder.RegisterType<CategoryValidator>().As<IEntityValidator<Category>>();
        }
    }
}
