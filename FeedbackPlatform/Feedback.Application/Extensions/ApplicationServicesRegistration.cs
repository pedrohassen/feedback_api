using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Security;
using FeedbackApp.Application.Services;
using FeedbackApp.Domain.Security;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackApp.Application.Extensions
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}
