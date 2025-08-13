using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Requests.Usuario;
using FeedbackApp.Application.Responses.Usuario;
using FeedbackApp.Domain.Entities;

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
                    opt.Condition(src => !string.IsNullOrWhiteSpace(src.NovoNome));
                    opt.MapFrom(src => src.NovoNome);
                })
                .ForMember(dest => dest.Email, opt =>
                {
                    opt.Condition(src => !string.IsNullOrWhiteSpace(src.NovoEmail));
                    opt.MapFrom(src => src.NovoEmail);
                })
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore());

            CreateMap<RegistroRequest, UsuarioArgument>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}