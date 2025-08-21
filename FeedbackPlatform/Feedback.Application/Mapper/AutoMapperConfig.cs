using AutoMapper;
using FeedbackApp.Application.Mapper.Profiles;

namespace FeedbackApp.Application.Mapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            try
            {
                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ArgumentToModelProfile());
                    cfg.AddProfile(new ArgumentToEntityProfile());
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new ModelToResponseProfile());
                    cfg.AddProfile(new RequestToArgumentProfile());
                    cfg.AddProfile(new RequestToModelProfile());
                    cfg.AddProfile(new RequestToEntityProfile());
                });

                config.AssertConfigurationIsValid();

                return config;
            }
            catch (AutoMapperConfigurationException ex)
            {
                Console.WriteLine("Erro na configuração do AutoMapper:");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
