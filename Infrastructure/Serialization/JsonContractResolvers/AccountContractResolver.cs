using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Serialization.JsonContractResolvers
{
    public class AccountContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyName == "Accounts" || property.PropertyName == "Contacts")
            {
                property.ShouldSerialize = i => false;
            }
            return property;
        }
    }
}
