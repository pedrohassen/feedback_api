using FeedbackApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackApp.Infrastructure.Extensions
{
    public static class DbContextServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("FeedbackDatabase")));

            return services;
        }
    }
}
