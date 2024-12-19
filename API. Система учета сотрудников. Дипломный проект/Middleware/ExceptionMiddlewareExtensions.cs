namespace BisnesManager.WebAPI.Diplom.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddlewareExtensions(this IApplicationBuilder builder )
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
