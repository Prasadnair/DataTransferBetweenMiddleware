namespace DataTranferBetweenMiddleware.MWare.Items
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IMiddlewareOne
    {
        private readonly RequestDelegate _next;

        public IMiddlewareOne(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["MTransfer"] = "Transering data";
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class IMiddlewareOneExtensions
    {
        public static IApplicationBuilder UseIMiddlewareOne(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IMiddlewareOne>();
        }
    }
}
