using AutoMapper;

namespace Infrastructure.Extensions
{
    public static class MapperExtensions
    {
        public static T Map<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

        public static T Map<T, TQ>(this TQ source)
        {
            return Mapper.Map<TQ, T>(source);
        }
    }
}
