using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Serialization.JsonContractResolvers
{
    public class AssetContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyName == "Assets")
            {
                property.ShouldSerialize = i => false;
            }
            return property;
        }
    }
}
