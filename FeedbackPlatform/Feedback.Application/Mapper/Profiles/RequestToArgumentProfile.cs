using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Requests;

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