using FeedbackApp.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackApp.Application.Extensions
{
    public static class UtilitiesRegistration
    {
        public static IServiceCollection AddUtilities(this IServiceCollection services)
        {
            services.AddScoped<IObjectConverter, ObjectConverter>();
            return services;
        }
    }
}
