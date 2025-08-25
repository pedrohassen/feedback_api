using AutoMapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Responses;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<UsuarioModel, UsuarioResponse>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore())
                .ForMember(dest => dest.Token, opt => opt.Ignore());

            CreateMap<FeedbackModel, FeedbackResponse>()
                .ForMember(dest => dest.Destinatario, opt => opt.Ignore())
                .ForMember(dest => dest.Remetente, opt => opt.Ignore());
        }
    }
}
