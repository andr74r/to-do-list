using Autofac;
using ToDoList.Common.Validators;
using ToDoList.Issue.Core.Services.Category;
using ToDoList.Issue.Core.Services.DefaultCategoryCreator;
using ToDoList.Issue.Core.Services.Issue;
using ToDoList.Issue.Core.Validators;
using ToDoList.Issue.Data.Entities;

namespace ToDoList.Issue.Core.Infrastructure
{
    public class AutofacIssueModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<IssueService>().As<IIssueService>();
            builder.RegisterType<DefaultCategoryCreator>().As<IDefaultCategoryCreator>();
            builder.RegisterType<IssueValidator>().As<IEntityValidator<Data.Entities.Issue>>();
            builder.RegisterType<CategoryValidator>().As<IEntityValidator<Category>>();
        }
    }
}
