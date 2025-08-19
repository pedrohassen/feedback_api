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
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}