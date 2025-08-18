using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Security;
using FeedbackApp.Application.Services;
using FeedbackApp.Domain.Security;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace FeedbackApp.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            MapperConfiguration mapperConfiguration = AutoMapperConfig.RegisterMappings();
            mapperConfiguration.AssertConfigurationIsValid();
            IMapper mapperInstance = new AutoMapper.Mapper(mapperConfiguration);

            services.AddSingleton<IMapper>(mapperInstance);
            services.AddScoped<IObjectConverter, ObjectConverter>();

            return services;
        }
    }
}
