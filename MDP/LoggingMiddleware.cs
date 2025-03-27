using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace MDP
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request
            _logger.LogInformation($"Incoming request: {context.Request.Method} {context.Request.Path}");

            // Copy the original response body stream
            var originalResponseBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                try
                {
                    // Call the next middleware in the pipeline
                    await _next(context);

                    // Log the response
                    _logger.LogInformation($"Response: {context.Response.StatusCode}");
                    responseBody.Seek(0, SeekOrigin.Begin);

                    var responseText = await new StreamReader(responseBody).ReadToEndAsync();
                    _logger.LogInformation($"Response Body: {responseText}");
                    responseBody.Seek(0, SeekOrigin.Begin);

                    if (!context.Request.RouteValues.ContainsKey("action")) // Check if it's MVC
                    {
                        var endpoint = context.GetEndpoint();
                        var modelState = context.Features.Get<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>();
                        if (modelState?.IsValid == false)
                        {
                            foreach (var error in modelState.Values.SelectMany(v => v.Errors))
                            {
                                _logger.LogError($"Model validation error: {error.ErrorMessage}");
                            }
                        }
                    }

                    // Copy the contents of the new memory stream (which contains the response) to the original stream
                    await responseBody.CopyToAsync(originalResponseBodyStream);

                }
                catch (Exception ex)
                {
                    // Log the exception
                    _logger.LogError($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }
    }
}


