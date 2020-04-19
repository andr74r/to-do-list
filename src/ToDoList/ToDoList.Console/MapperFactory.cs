using AutoMapper;
using ToDoList.Core.Infrastructure;

namespace ToDoList.Console
{
    public static class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                AutoMapperCoreModule.Register(cfg);
            });

            return new Mapper(configuration);
        }
    }
}
