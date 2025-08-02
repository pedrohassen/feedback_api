using AutoMapper;
using FeedbackApp.Application.DTOs.Requests.Usuario;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class RegistroRequestToUsuarioProfile : Profile
    {
        public RegistroRequestToUsuarioProfile()
        {
            CreateMap<RegistroRequest, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ForMember(dest => dest.FeedbacksRecebidos, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
