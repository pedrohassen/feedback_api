using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ArgumentToEntityProfile : Profile
    {
        public ArgumentToEntityProfile()
        {
            CreateMap<UsuarioArgument, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.MapFrom(src => src.Senha))
                .ReverseMap();
        }
    }
}