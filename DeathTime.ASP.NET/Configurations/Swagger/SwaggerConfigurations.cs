using DeathTime.ASP.NET.Configurations.Swagger.Filter;
using Microsoft.OpenApi.Models;

namespace DeathTime.ASP.NET.Configurations.Swagger
{
    public static class SwaggerConfigurations
    {
        public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection service)
        {
            service.AddSwaggerGen(op =>
            {
                op.EnableAnnotations();
                op.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Death Time.NET Api",
                    Description = "Api demo of .NET about Death Time Middleware"
                });
                op.SchemaFilter<SwaggerSchemaExampleFilter>();
            });
            return service;
        }
    }
}
