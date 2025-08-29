using AutoMapper;
using FeedbackApp.Application.Responses;
using FeedbackApp.Application.Arguments;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ResponseToArgumentProfile : Profile
    {
        public ResponseToArgumentProfile()
        {
            CreateMap<UsuarioResponse, UsuarioArgument>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Senha, opt => opt.Ignore());
        }
    }
}
