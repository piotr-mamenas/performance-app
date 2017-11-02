using AutoMapper;

namespace Infrastructure.AutoMapper
{
    public static class MapperExtensions
    {
        public static T Map<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

        public static T Map<T, Q>(this Q source)
        {
            return Mapper.Map<Q, T>(source);
        }
    }
}
