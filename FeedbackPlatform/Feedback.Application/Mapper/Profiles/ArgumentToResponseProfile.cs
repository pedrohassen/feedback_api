using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Responses.Usuario;
using FeedbackApp.Application.Arguments.Usuario;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ArgumentToResponseProfile : Profile
    {
        public ArgumentToResponseProfile()
        {
            CreateMap<UsuarioArgument, UsuarioResponse>()
                .ReverseMap()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore());

            CreateMap<UsuarioArgument, LoginResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore());
        }
    }
}