namespace EpidimiologyReport
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorEventHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception happened dou to invoking the http context");
                throw;
            }
        }
    }

    public static class ErrorLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLoggingMiddleware>();
        }
    }
}
 