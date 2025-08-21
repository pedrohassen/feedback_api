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
                .ReverseMap();
        }
    }
}