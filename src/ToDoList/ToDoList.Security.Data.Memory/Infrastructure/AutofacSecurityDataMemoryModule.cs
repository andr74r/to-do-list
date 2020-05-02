using Autofac;
using ToDoList.Security.Data.Memory.Repository;
using ToDoList.Security.Data.Repositories;

namespace ToDoList.Security.Data.Memory.Infrastructure
{
    public class AutofacSecurityDataMemoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
