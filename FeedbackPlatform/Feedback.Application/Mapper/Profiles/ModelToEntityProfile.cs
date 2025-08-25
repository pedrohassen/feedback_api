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
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Senha, opt => opt.Ignore())
                .ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore())
                .ForMember(dest => dest.FeedbacksEnviados, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<FeedbackModel, Feedback>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.Destinatario, opt => opt.Ignore())
                .ForMember(dest => dest.Remetente, opt => opt.Ignore());

            CreateMap<Feedback, FeedbackModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Texto, opt => opt.MapFrom(src => src.Texto))
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.DataCriacao))
                .ForMember(dest => dest.DataAtualizacao, opt => opt.MapFrom(src => src.DataAtualizacao))
                .ForMember(dest => dest.Destinatario, opt => opt.Ignore())
                .ForMember(dest => dest.Remetente, opt => opt.Ignore());
        }
    }
}
