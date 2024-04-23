using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace API.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _host;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IHostEnvironment host)
        {
            this._logger = logger;
            this._host = host;
        }
        /*    private readonly ILogger<ExceptionMiddleware> _logger;
            private readonly IHostEnvironment _env;
            public ExceptionMiddleware(ILogger<ExceptionMiddleware> _logger, IHostEnvironment env)
            {
                _env = env;
                _logger = _logger;
            
            }

            public async Task InvokeAsync(HttpContext context, RequestDelegate next)
            {
                try
                {
                    await next(context);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 500;

                    var response = new ProblemDetails
                    {
                        Status = 500,
                        Detail = _env.IsDevelopment() ? ex.StackTrace?.ToString() : null,
                        Title = ex.Message
                    };

                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var json = JsonSerializer.Serialize(response, options);
                    await context.Response.WriteAsync(json);
                }
            }*/
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new ProblemDetails
                {
                    Title = ex.Message,
                    Status = 500,
                    Detail = _host.IsDevelopment() ? ex.StackTrace?.ToString() : null
                };

                var errorSerialize = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var result = JsonSerializer.Serialize(response, errorSerialize);
                await context.Response.WriteAsync(result);
            }
        }
    }
}