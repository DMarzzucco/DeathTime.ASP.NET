using DeathTime.ASP.NET.Configurations.Swagger.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace DeathTime.ASP.NET.User.DTOs
{
    public class UpdateUserDTO
    {
        [SwaggerSchema("User Name")]
        [SwaggerSchemaExample("Dario")]
        public string? Name { get; set; }

        [SwaggerSchema("User Age")]
        [SwaggerSchemaExample("27")]
        public string? Age { get; set; }

        [SwaggerSchema("User Email")]
        [SwaggerSchemaExample("dar@gmial.com")]
        public string? Email { get; set; }
    }
}
