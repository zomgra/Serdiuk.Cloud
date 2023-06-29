using Serdiuk.Cloud.Api.Exceptions;

namespace Serdiuk.Cloud.Api.Middlewares
{
    public class CloudExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CloudExceptionMiddleware> _logger;

        public CloudExceptionMiddleware(RequestDelegate next, ILogger<CloudExceptionMiddleware> logger)
        {
            this._next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CloudBadRequestException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
