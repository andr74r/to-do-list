using Autofac;
using ToDoList.Security.Core.Services.Hash;
using ToDoList.Security.Core.Services.User;

namespace ToDoList.Security.Core.Infrastructure
{
    public class AutofacSecurityCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<HashProvider>().As<IHashProvider>();
        }
    }
}
