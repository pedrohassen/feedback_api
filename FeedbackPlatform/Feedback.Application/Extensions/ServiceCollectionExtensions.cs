using Microsoft.Extensions.DependencyInjection;

namespace FeedbackApp.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services
                .AddApplicationServices()
                .AddAutoMapperConfig()
                .AddUtilities();

            return services;
        }
    }
}
