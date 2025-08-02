using FeedbackApp.CrossCutting.Authorization;

namespace FeedbackApp.API.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy(Policy.AdminOnly, policy =>
                {
                    policy.RequireClaim(Claim.Role, "Admin");
                });

            return services;
        }
    }
}
