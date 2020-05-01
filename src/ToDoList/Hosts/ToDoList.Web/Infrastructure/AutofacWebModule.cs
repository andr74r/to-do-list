using Autofac;
using AutoMapper;
using ToDoList.Core.Infrastructure;
using ToDoList.Data.Memory.Infrastructure;
using ToDoList.Security.Core.Services.User;

namespace ToDoList.Web.Infrastructure
{
    public class AutofacWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => MapperFactory.CreateMapper()).As<IMapper>();

            builder.RegisterModule(new AutofacDataMemoryModule());

            builder.RegisterModule(new AutofacCoreModule());

            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
