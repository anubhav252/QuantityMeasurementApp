namespace ApiGateway.Middleware
{
    /// <summary>
    /// Logs all incoming requests through the gateway and forwards
    /// the Authorization header to downstream microservices.
    /// </summary>
    public class GatewayLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GatewayLoggingMiddleware> _logger;

        public GatewayLoggingMiddleware(RequestDelegate next, ILogger<GatewayLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(
                "[Gateway] {Method} {Path} from {IP}",
                context.Request.Method,
                context.Request.Path,
                context.Connection.RemoteIpAddress);

            await _next(context);

            _logger.LogInformation(
                "[Gateway] Response {StatusCode} for {Path}",
                context.Response.StatusCode,
                context.Request.Path);
        }
    }
}
