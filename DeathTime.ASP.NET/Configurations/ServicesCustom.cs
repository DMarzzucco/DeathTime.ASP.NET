using DeathTime.ASP.NET.User.Repository.Interfaces;
using DeathTime.ASP.NET.User.Repository;
using DeathTime.ASP.NET.User.Services.Interfaces;
using DeathTime.ASP.NET.User.Services;
using DeathTime.ASP.NET.Utils.Filters;

namespace DeathTime.ASP.NET.Configurations
{
    public static class ServicesCustom
    {
        public static IServiceCollection AddServicesCustom(this IServiceCollection service)
        {
            service.AddScoped<GlobalFilterExceptions>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserServicesImpl, UserServices>();

            return service;
        }
    }
}
