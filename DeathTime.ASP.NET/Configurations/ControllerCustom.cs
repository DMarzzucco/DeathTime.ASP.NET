using DeathTime.ASP.NET.Utils.Filters;

namespace DeathTime.ASP.NET.Configurations
{
    public static class ControllerCustom
    {
        public static IServiceCollection AddControllersCustom(this IServiceCollection service)
        {
            service.AddControllers(op =>
            {
                op.Filters.Add<GlobalFilterExceptions>();
            });
            return service;
        }
    }
}
