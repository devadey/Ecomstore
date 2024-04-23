namespace API.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseFactoryActivatedMiddleware(
            this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionMiddleware>();
    }
}
