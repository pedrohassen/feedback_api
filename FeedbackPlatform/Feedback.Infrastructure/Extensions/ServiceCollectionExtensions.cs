using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FeedbackApp.Infrastructure.Data;
using FeedbackApp.Domain.Interfaces;

namespace FeedbackApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("FeedbackDatabase")));

            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            return services;
        }
    }
}
