using AutoMapper;
using FeedbackApp.Application.Arguments.Usuario;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ArgumentToEntityProfile : Profile
    {
        public ArgumentToEntityProfile()
        {
            CreateMap<UsuarioArgument, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}