using AutoMapper;
using FeedbackApp.Application.DTOs.Requests.Feedback;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class AtualizarFeedbackRequestToFeedbackProfile : Profile
    {
        public AtualizarFeedbackRequestToFeedbackProfile()
        {
            CreateMap<AtualizarFeedbackRequest, Feedback>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataEnvio, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioId, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
