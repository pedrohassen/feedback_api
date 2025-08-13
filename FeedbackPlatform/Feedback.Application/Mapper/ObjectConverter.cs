using AutoMapper;

namespace FeedbackApp.Application.Mapper
{
    public class ObjectConverter : IObjectConverter
    {
        private readonly IMapper _mapper;

        public ObjectConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public T Map<T>(object source)
        {
            return _mapper.Map<T>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
