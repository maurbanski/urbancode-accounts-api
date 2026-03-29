using NLog;

namespace Urbancode.Accounts.API.Interface.Middleware;

public class RequestLoggingMiddleware : IMiddleware
{
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var requestId = context.TraceIdentifier; // or custom logic
        var path = context.Request.Path;
        var endpoint = context.GetEndpoint().DisplayName;
        
        using (MappedDiagnosticsLogicalContext.SetScoped("requestId", requestId))
        {
            _logger.LogInformation($"Path ({path}) accessed and mapped to endpoint ({endpoint})");
            await next(context);
        }
    }
}