using FeedbackApp.API.Extensions;
using FeedbackApp.Application.Extensions;
using FeedbackApp.Infrastructure.Extensions;

namespace FeedbackApp.API.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAllDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddApplicationLayer()
                .AddInfrastructureLayer(configuration)
                .AddApiLayer(configuration);

            return services;
        }
    }
}
