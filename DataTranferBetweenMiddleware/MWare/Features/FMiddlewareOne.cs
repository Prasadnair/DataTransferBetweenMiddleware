namespace DataTranferBetweenMiddleware.MWare.Features
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FMiddlewareOne
    {
        private readonly RequestDelegate _next;

        public FMiddlewareOne(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var sample = new SampleFeature
            {
                Description = "Testing data transfer"
            };
            httpContext.Features.Set<SampleFeature>(sample);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FMiddlewareOneExtensions
    {
        public static IApplicationBuilder UseFMiddlewareOne(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FMiddlewareOne>();
        }
    }
}
