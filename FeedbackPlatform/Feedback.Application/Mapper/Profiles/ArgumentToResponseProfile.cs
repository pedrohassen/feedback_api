using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Requests.Usuario;
using FeedbackApp.Application.Responses.Usuario;
using FeedbackApp.Domain.Entities;

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