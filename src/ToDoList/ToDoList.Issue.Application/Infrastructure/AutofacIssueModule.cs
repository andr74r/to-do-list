using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace ToDoList.Issue.Core.Infrastructure
{
    public class AutofacIssueModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddMediatR(ThisAssembly);
        }
    }
}
