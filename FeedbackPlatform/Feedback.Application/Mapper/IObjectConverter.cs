namespace FeedbackApp.Application.Mapper
{
    public interface IObjectConverter
    {
        T Map<T>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
