using FeedbackApp.API.Middlewares;

namespace FeedbackApp.API.Extensions
{
    public static class ExceptionMiddlewareRegistration
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
