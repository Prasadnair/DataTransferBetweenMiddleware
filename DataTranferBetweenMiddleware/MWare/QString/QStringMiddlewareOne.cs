using Microsoft.AspNetCore.Http.Extensions;

namespace DataTranferBetweenMiddleware.MWare.QString
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class QStringMiddlewareOne
    {
        private readonly RequestDelegate _next;

        public QStringMiddlewareOne(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            List<KeyValuePair<string, string>> queryparameters = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> newqueryparameter = new KeyValuePair<string, string>("qstring", "fromOne");
            
            queryparameters.Add(newqueryparameter);
            
            var qb1 = new QueryBuilder(queryparameters);
            //pass query string to another middleware
            httpContext.Request.QueryString = qb1.ToQueryString();

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class QStringMiddlewareOneExtensions
    {
        public static IApplicationBuilder UseQStringMiddlewareOne(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<QStringMiddlewareOne>();
        }
    }
}
