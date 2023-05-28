using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DataTranferBetweenMiddleware.MWare.QString
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class QStringMiddlewareTwo
    {
        private readonly RequestDelegate _next;

        public QStringMiddlewareTwo(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //read data from query string
            var items2 = httpContext.Request.Query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
            Console.Write(items2[0].Value);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class QStringMiddlewareTwoExtensions
    {
        public static IApplicationBuilder UseQStringMiddlewareTwo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<QStringMiddlewareTwo>();
        }
    }
}
