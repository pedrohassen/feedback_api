using AutoMapper;
using FeedbackApp.Application.Requests.Usuario;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class RequestToEntityProfile : Profile
    {
        public RequestToEntityProfile()
        {
            CreateMap<UsuarioRequest, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore());
        }
    }
}
