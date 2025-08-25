using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Models;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ArgumentToModelProfile : Profile
    {
        public ArgumentToModelProfile()
        {
            CreateMap<UsuarioArgument, UsuarioModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<FeedbackArgument, FeedbackModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.Destinatario, opt => opt.Ignore())
                .ForMember(dest => dest.Remetente, opt => opt.Ignore());
        }
    }
}
