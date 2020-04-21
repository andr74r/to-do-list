using AutoMapper;
using ToDoList.Core.Infrastructure;

namespace ToDoList.Web.Infrastructure
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            return new Mapper(GetConfigurationProvider());
        }

        private static IConfigurationProvider GetConfigurationProvider()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                AutoMapperCoreModule.Register(cfg);
                AutoMapperWebModule.Register(cfg);
            });

            return configuration;
        }
    }
}
