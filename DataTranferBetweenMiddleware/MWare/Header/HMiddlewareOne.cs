using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DataTranferBetweenMiddleware.MWare.Header
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HMiddlewareOne
    {
        private readonly RequestDelegate _next;

        public HMiddlewareOne(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            // Add Custom Header
            httpContext.Request.Headers.Add("x-my-custom-header", "HMiddlewareOne");

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HMiddlewareOneExtensions
    {
        public static IApplicationBuilder UseHMiddlewareOne(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HMiddlewareOne>();
        }
    }
}
