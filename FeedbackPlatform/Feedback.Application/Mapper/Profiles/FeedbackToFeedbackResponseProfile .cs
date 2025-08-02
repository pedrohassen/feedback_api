using AutoMapper;
using FeedbackApp.Application.DTOs.Responses.Feedback;

namespace FeedbackApp.Application.Mapper.Profiles
{
    public class FeedbackToFeedbackResponseProfile : Profile
    {
        public FeedbackToFeedbackResponseProfile()
        {
            CreateMap<Feedback, FeedbackResponse>();
        }
    }
}
