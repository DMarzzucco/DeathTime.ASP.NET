using DeathTime.ASP.NET.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DeathTime.ASP.NET.Utils.Filters
{
    public class GlobalFilterExceptions : IExceptionFilter
    {
        private readonly ILogger<GlobalFilterExceptions> _logger;
        public GlobalFilterExceptions(ILogger<GlobalFilterExceptions> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext ctx)
        {
            _logger.LogError(ctx.Exception, "An unhandled exception ocurred.");

            var statusCode = ctx.Exception switch
            {
                BadRequestExceptions => 400,
                UnauthorizedAccessException => 401,
                KeyNotFoundException => 404,
                ConflictExceptions => 409,
                _ => 500
            };

            var response = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = statusCode switch
                {
                    400 => ctx.Exception.Message,
                    401 => ctx.Exception.Message,
                    404 => ctx.Exception.Message,
                    409 => ctx.Exception.Message,
                    _ => ctx.Exception.Message
                },
                Details = statusCode == 500 ? ctx.Exception.Message : null
            };
            ctx.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };
            ctx.ExceptionHandled = true;
        }
        public class ErrorResponse
        {
            public int StatusCode { get; set; }
            public required string Message { get; set; }
            public string? Details { get; set; }
        }
    }
}
