namespace DeathTime.ASP.NET.Configurations
{
    public static class CorsConfigurations
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection service)
        {
            service.AddCors(o =>
            {
                o.AddPolicy("DeathTimerCors", b =>
                {
                    b.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            return service;
        }
    }
}
