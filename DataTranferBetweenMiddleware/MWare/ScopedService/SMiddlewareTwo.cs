namespace DataTranferBetweenMiddleware.MWare.ScopedService
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SMiddlewareTwo
    {
        private readonly RequestDelegate _next;
        private readonly IScopedService _scopedService;
        public SMiddlewareTwo(RequestDelegate next, IScopedService scopedService)
        {
            _next = next;
            _scopedService = scopedService;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var data = _scopedService.Data;

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SMiddlewareTwoExtensions
    {
        public static IApplicationBuilder UseSMiddlewareTwo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SMiddlewareTwo>();
        }
    }
}
