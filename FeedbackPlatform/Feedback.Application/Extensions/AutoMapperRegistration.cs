using AutoMapper;
using FeedbackApp.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackApp.Application.Extensions
{
    public static class AutoMapperRegistration
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = AutoMapperConfig.RegisterMappings();
            mapperConfiguration.AssertConfigurationIsValid();
            IMapper mapperInstance = new AutoMapper.Mapper(mapperConfiguration);

            services.AddSingleton<IMapper>(mapperInstance);

            return services;
        }
    }
}
