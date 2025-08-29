namespace FeedbackApp.API.Extensions
{
    public static class ApiLayerExtensions
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddJwtAuthentication(configuration)
                .AddSwagger()
                .AddHttpContextAccessor();

            return services;
        }

        public static WebApplication UseApiLayer(this WebApplication app)
        {
            app.UseExceptionHandling();
            app.UseSwaggerUIIfDev();

            return app;
        }
    }
}
