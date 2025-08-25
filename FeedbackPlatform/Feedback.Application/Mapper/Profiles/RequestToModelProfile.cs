using AutoMapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Requests;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            CreateMap<UsuarioRequest, UsuarioModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<FeedbackRequest, FeedbackModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.Destinatario, opt => opt.Ignore())
                .ForMember(dest => dest.Remetente, opt => opt.Ignore());
        }
    }
}
