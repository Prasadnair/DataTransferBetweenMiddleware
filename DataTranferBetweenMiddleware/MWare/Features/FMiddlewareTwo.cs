namespace DataTranferBetweenMiddleware.MWare.Features
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FMiddlewareTwo
    {
        private readonly RequestDelegate _next;

        public FMiddlewareTwo(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var sample = httpContext.Features.Get<SampleFeature>();
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FMiddlewareTwoExtensions
    {
        public static IApplicationBuilder UseFMiddlewareTwo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FMiddlewareTwo>();
        }
    }
}
