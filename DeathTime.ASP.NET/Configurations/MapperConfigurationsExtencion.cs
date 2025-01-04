using AutoMapper;
using DeathTime.ASP.NET.Mapper;

namespace DeathTime.ASP.NET.Configurations
{
    public static class MapperConfigurationsExtencion
    {
        public static IServiceCollection AddMapperConfigurations(this IServiceCollection service)
        {
            var mappConf = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            IMapper mapper = mappConf.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }
}
