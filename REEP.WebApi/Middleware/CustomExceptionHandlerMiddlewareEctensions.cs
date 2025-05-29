namespace REEP.WebApi.Middleware
{
    public static class CustomExceptionHandlerMiddlewareEctensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this
            IApplicationBuilder builer)
        {
            return builer.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
