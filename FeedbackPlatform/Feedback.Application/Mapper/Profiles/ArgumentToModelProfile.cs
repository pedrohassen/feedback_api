using AutoMapper;
using FeedbackApp.Application.Arguments.Usuario;
using FeedbackApp.Application.Requests.Usuario;
using FeedbackApp.Application.Responses.Usuario;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ArgumentToModelProfile : Profile
    {
        public ArgumentToModelProfile()
        {
            CreateMap<UsuarioArgument, UsuarioModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.SenhaHash, opt => opt.MapFrom(src => src.SenhaHash))
                .ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}