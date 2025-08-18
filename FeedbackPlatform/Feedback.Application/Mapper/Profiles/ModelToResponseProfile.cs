using AutoMapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Responses.Usuario;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<UsuarioModel, UsuarioResponse>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore())
                .ForMember(dest => dest.Token, opt => opt.Ignore());
        }
    }
}