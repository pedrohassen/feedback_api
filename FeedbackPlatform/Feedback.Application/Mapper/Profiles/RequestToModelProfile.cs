using AutoMapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Requests.Usuario;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            CreateMap<UsuarioRequest, UsuarioModel>()
                .ForMember(dest => dest.SenhaHash, opt =>
                    opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            //.ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore());
        }
    }
}