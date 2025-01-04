using DeathTime.ASP.NET.Configurations.Swagger.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace DeathTime.ASP.NET.User.DTOs
{
    public class CreateUserDTO
    {
        [SwaggerSchema("User Name")]
        [SwaggerSchemaExample("Dario")]
        public required string Name { get; set; }

        [SwaggerSchema("User Age")]
        [SwaggerSchemaExample("27")]
        public required string Age { get; set; }

        [SwaggerSchema("User Email")]
        [SwaggerSchemaExample("dar@gmial.com")]
        public required string Email { get; set; }
    }
}
