namespace DeathTime.ASP.NET.Utils.Exceptions
{
    public class ConflictExceptions : Exception
    {
        public ConflictExceptions(string message) : base(message)
        {

        }
    }
    public class BadRequestExceptions : Exception
    {
        public BadRequestExceptions(string message) : base(message)
        {

        }
    }
}
