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
                    cfg.AddProfile(new RegistroRequestToUsuarioProfile());
                    cfg.AddProfile(new UsuarioToUsuarioResponseProfile());
                    cfg.AddProfile(new AtualizarUsuarioRequestToUsuarioProfile());
                    cfg.AddProfile(new CriarFeedbackRequestToFeedbackProfile());
                    cfg.AddProfile(new FeedbackToFeedbackResponseProfile());
                    cfg.AddProfile(new AtualizarFeedbackRequestToFeedbackProfile());
                });

                config.AssertConfigurationIsValid();

                return config;
            }
            catch (AutoMapperConfigurationException ex)
            {
                Console.WriteLine("Erro na configuração do AutoMapper:");
                Console.WriteLine(ex.Message);
                throw; // relança para que continue quebrando e você possa ver no debug
            }
        }
    }
}
