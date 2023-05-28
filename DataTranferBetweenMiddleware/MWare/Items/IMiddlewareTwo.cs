namespace DataTranferBetweenMiddleware.MWare.Items
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IMiddlewareTwo
    {
        private readonly RequestDelegate _next;

        public IMiddlewareTwo(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var transfer = httpContext.Items["MTransfer"];

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class IMiddlewareTwoExtensions
    {
        public static IApplicationBuilder UseIMiddlewareTwo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IMiddlewareTwo>();
        }
    }
}
