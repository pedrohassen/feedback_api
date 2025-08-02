using AutoMapper;
using FeedbackApp.Application.DTOs.Responses.Usuario;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class UsuarioToUsuarioResponseProfile : Profile
    {
        public UsuarioToUsuarioResponseProfile()
        {
            CreateMap<Usuario, UsuarioResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
        }
    }
}
