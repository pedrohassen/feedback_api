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
                    //cfg.AddProfile(new FeedbackProfiles());
                    cfg.AddProfile(new ArgumentToModelProfile());
                    cfg.AddProfile(new ArgumentToResponseProfile());
                    cfg.AddProfile(new ModelToResponseProfile());
                    cfg.AddProfile(new RequestToArgumentProfile());
                    cfg.AddProfile(new RequestToModelProfile());
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
