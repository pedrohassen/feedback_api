using AutoMapper;
using FeedbackApp.Application.DTOs.Requests.Usuario;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class AtualizarUsuarioRequestToUsuarioProfile : Profile
    {
        public AtualizarUsuarioRequestToUsuarioProfile()
        {
            CreateMap<AtualizarUsuarioRequest, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ForSourceMember(src => src.NovaSenha, opt => opt.DoNotValidate())
                .ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore());
        }
    }
}
