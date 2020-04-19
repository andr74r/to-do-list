using Autofac;
using AutoMapper;
using ToDoList.Core.Infrastructure;
using ToDoList.Data.Memory.Infrastructure;

namespace ToDoList.Console
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacDataMemoryModule());

            builder.RegisterModule(new AutofacCoreModule());

            builder.Register(ctx => MapperFactory.CreateMapper()).As<IMapper>();

            return builder.Build();
        }
    }
}
