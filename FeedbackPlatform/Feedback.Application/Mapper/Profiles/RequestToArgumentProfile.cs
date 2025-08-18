using AutoMapper;
using FeedbackApp.Application.Arguments.Usuario;
using FeedbackApp.Application.Requests.Usuario;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class RequestToArgumentProfile : Profile
    {
        public RequestToArgumentProfile()
        {
            CreateMap<UsuarioRequest, UsuarioArgument>()
                .ReverseMap();
        }
    }
}