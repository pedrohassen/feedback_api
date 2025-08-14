using AutoMapper;
using FeedbackApp.Application.Arguments.Usuario;
using FeedbackApp.Application.Requests.Usuario;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class RequestToArgumentProfile : Profile
    {
        public RequestToArgumentProfile()
        {
            CreateMap<AtualizarUsuarioRequest, UsuarioArgument>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Nome, opt =>
                {
                    opt.Condition(src => !string.IsNullOrWhiteSpace(src.Nome));
                    opt.MapFrom(src => src.Nome);
                })
                .ForMember(dest => dest.Email, opt =>
                {
                    opt.Condition(src => !string.IsNullOrWhiteSpace(src.Email));
                    opt.MapFrom(src => src.Email);
                })
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore());

            CreateMap<RegistroRequest, UsuarioArgument>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}