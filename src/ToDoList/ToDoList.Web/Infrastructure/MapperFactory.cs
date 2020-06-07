using AutoMapper;
using ToDoList.Issue.Core.Infrastructure;
using ToDoList.Security.Core.Infrastructure;

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
                AutoMapperIssueModule.Register(cfg);
                AutoMapperWebModule.Register(cfg);
                AutoMapperSecurityCoreModule.Register(cfg);
            });

            return configuration;
        }
    }
}
