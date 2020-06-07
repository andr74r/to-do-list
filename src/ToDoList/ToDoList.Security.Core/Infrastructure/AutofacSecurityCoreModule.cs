using Autofac;
using ToDoList.Common.Validators;
using ToDoList.Security.Core.Services.Hash;
using ToDoList.Security.Core.Services.User;
using ToDoList.Security.Core.Validators;
using ToDoList.Security.Data.Entities;

namespace ToDoList.Security.Core.Infrastructure
{
    public class AutofacSecurityCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<HashProvider>().As<IHashProvider>();
            builder.RegisterType<UserValidator>().As<IEntityValidator<User>>();
        }
    }
}
