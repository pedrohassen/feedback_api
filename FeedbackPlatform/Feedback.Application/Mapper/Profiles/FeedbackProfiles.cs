//using AutoMapper;
//using FeedbackApp.Application.Arguments;
//using FeedbackApp.Application.Requests.Feedback;
//using FeedbackApp.Application.Responses.Feedback;
//using FeedbackApp.Domain.Entities;

//namespace FeedbackApp.Application.Mapper.Profiles
//{
//    public class FeedbackProfiles : Profile
//    {
//        public FeedbackProfiles()
//        {
//            CreateMap<Feedback, FeedbackResponse>();

//            CreateMap<CriarFeedbackRequest, Feedback>()
//                .ForMember(dest => dest.DataEnvio, opt => opt.Ignore())
//                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

//            CreateMap<Feedback, FeedbackArgument>().ReverseMap();

//            CreateMap<AtualizarFeedbackRequest, Feedback>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ForMember(dest => dest.DataEnvio, opt => opt.Ignore())
//                .ForMember(dest => dest.Usuario, opt => opt.Ignore());
//        }
//    }
//}