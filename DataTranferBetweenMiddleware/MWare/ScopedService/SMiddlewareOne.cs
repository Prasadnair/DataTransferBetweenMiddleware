namespace DataTranferBetweenMiddleware.MWare.ScopedService
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SMiddlewareOne
    {
        private readonly RequestDelegate _next;
        private readonly IScopedService _scopedService;
        public SMiddlewareOne(RequestDelegate next, IScopedService scopedService)
        {
            _next = next;
            _scopedService = scopedService;
        }

        public Task Invoke(HttpContext httpContext)
        {
            _scopedService.Data = "Testing data transfer using Scoped Service";
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SMiddlewareOneExtensions
    {
        public static IApplicationBuilder UseSMiddlewareOne(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SMiddlewareOne>();
        }
    }
}
