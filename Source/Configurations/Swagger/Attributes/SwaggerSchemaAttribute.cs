namespace Source.Configurations.Swagger.Attributes
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Parameter |
        AttributeTargets.Property |
        AttributeTargets.Enum, AllowMultiple = false
        )]
    public class SwaggerSchemaAttribute : Attribute
    {
        public SwaggerSchemaAttribute(string example)
        {
            Example = example;
        }
        public string Example { get; set; }
    }
}
