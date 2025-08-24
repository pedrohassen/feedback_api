using FeedbackApp.API.Extensions;
using FeedbackApp.Application.Extensions;
using FeedbackApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp.API
{
    public class Program
    {
        protected Program()
        {
        }

        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder);

            WebApplication app = builder.Build();

            ConfigureApp(app);

            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PermitirSwagger", policy =>
                {
                    policy.WithOrigins(
                        "https://localhost:7235",
                        "http://localhost:5233"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddJwtAuthentication(builder.Configuration)
                .AddSwagger();
        }

        private static void ConfigureApp(WebApplication app)
        {
            app.UseExceptionHandling();
            app.UseHttpsRedirection();
            app.UseCors("PermitirSwagger");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerUIIfDev();
            app.MapControllers();
        }
    }
}
