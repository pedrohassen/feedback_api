using FeedbackApp.Domain.Security;
using FeedbackApp.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackApp.Infrastructure.Extensions
{
    public static class SecurityRegistration
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();

            return services;
        }
    }
}
