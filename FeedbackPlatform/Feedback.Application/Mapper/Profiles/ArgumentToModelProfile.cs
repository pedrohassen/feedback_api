using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Models;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ArgumentToModelProfile : Profile
    {
        public ArgumentToModelProfile()
        {
            CreateMap<UsuarioArgument, UsuarioModel>()
                .ForMember(dest => dest.SenhaHash, opt => opt.MapFrom(src => src.Senha))
                .ReverseMap();
        }
    }
}