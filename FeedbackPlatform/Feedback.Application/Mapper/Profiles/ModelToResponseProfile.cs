using AutoMapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Requests.Usuario;
using FeedbackApp.Application.Responses.Usuario;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<UsuarioModel, UsuarioResponse>();

            CreateMap<UsuarioModel, LoginResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
        }
    }
}