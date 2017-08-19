using AutoMapper;

namespace Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static T Map<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
