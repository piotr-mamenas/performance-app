using System.Collections.Generic;
using System.Reflection;

namespace Infrastructure.Helpers
{
    public static class ReflectionHelper
    {
        public static bool IsPropertyACollection(this PropertyInfo property)
        {
            return property.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null && property.PropertyType != typeof(string);
        }
    }
}