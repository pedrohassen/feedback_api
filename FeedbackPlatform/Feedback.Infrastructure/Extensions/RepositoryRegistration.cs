using FeedbackApp.Application.Interfaces;
using FeedbackApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackApp.Infrastructure.Extensions
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            return services;
        }
    }
}
