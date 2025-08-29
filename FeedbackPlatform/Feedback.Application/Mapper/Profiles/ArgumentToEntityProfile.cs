using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ArgumentToEntityProfile : Profile
    {
        public ArgumentToEntityProfile()
        {
            CreateMap<UsuarioArgument, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore())
                .ForMember(dest => dest.FeedbacksEnviados, opt => opt.Ignore());

            CreateMap<FeedbackArgument, Feedback>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.Destinatario, opt => opt.Ignore())
                .ForMember(dest => dest.Remetente, opt => opt.Ignore());
        }
    }
}
