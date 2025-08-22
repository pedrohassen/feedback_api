using AutoMapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Requests;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            CreateMap<UsuarioRequest, UsuarioModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}