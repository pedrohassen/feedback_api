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
                .ForMember(dest => dest.Id, opt => opt.Condition((src, dest, srcMember) => srcMember != 0));

            CreateMap<FeedbackRequest, FeedbackArgument>()
                .ForMember(dest => dest.Id, opt => opt.Condition((src, dest, srcMember) => srcMember != 0))
                .ForMember(dest => dest.Destinatario, opt => opt.Ignore())
                .ForMember(dest => dest.Remetente, opt => opt.Ignore())
                .ForMember(dest => dest.RemetenteId, opt => opt.Ignore())
                .ForMember(dest => dest.DestinatarioId, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore());
        }
    }
}
