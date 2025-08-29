using AutoMapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UsuarioModel, Usuario>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore())
                .ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore())
                .ForMember(dest => dest.FeedbacksEnviados, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<FeedbackModel, Feedback>()
                .ForMember(dest => dest.Id, opt => opt.Condition((src, dest, srcMember) => srcMember != 0))
                .ForMember(dest => dest.Destinatario, opt => opt.Ignore())
                .ForMember(dest => dest.Remetente, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
