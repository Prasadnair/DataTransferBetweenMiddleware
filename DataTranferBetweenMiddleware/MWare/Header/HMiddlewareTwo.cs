using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DataTranferBetweenMiddleware.MWare.Header
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HMiddlewareTwo
    {
        private readonly RequestDelegate _next;

        public HMiddlewareTwo(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string data = httpContext.Request.Headers["x-my-custom-header"];
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HMiddlewareTwoExtensions
    {
        public static IApplicationBuilder UseHMiddlewareTwo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HMiddlewareTwo>();
        }
    }
}
