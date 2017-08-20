using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.Helpers
{
    public static class AttributeHelper
    {
        public static Dictionary<object, List<Attribute>> AttributeCache { get; } = new Dictionary<object, List<Attribute>>();
        
        public static List<Attribute> GetTypeAttributes<TType>()
        {
            return GetTypeAttributes(typeof(TType));
        }

        public static List<Attribute> GetTypeAttributes(Type type)
        {
            return LockAndGetAttributes(type, tp => ((Type)tp).GetCustomAttributes(true));
        }

        public static List<TAttributeType> GetTypeAttributes<TAttributeType>(Type type, Func<TAttributeType, bool> predicate = null)
        {
            return
                GetTypeAttributes(type)
                    .Where<Attribute, TAttributeType>()
                    .Where(attr => predicate == null || predicate(attr))
                    .ToList();
        }

        public static List<TAttributeType> GetTypeAttributes<TType, TAttributeType>(Func<TAttributeType, bool> predicate = null)
        {
            return GetTypeAttributes(typeof(TType), predicate);
        }

        public static TAttributeType GetTypeAttribute<TType, TAttributeType>(Func<TAttributeType, bool> predicate = null)
        {
            return
                GetTypeAttribute(typeof(TType), predicate);
        }

        public static TAttributeType GetTypeAttribute<TAttributeType>(Type type, Func<TAttributeType, bool> predicate = null)
        {
            return
                GetTypeAttributes(type, predicate)
                    .FirstOrDefault();
        }

        public static bool HasTypeAttribute<TType, TAttributeType>(Func<TAttributeType, bool> predicate = null)
        {
            return HasTypeAttribute(typeof(TType), predicate);
        }

        public static bool HasTypeAttribute<TAttributeType>(Type type, Func<TAttributeType, bool> predicate = null)
        {
            return GetTypeAttribute(type, predicate) != null;
        }
        
        public static List<Attribute> GetMemberAttributes<TType>(Expression<Func<TType, object>> action)
        {
            return GetMemberAttributes(GetMember(action));
        }

        public static List<TAttributeType> GetMemberAttributes<TType, TAttributeType>(
            Expression<Func<TType, object>> action,
            Func<TAttributeType, bool> predicate = null)
            where TAttributeType : Attribute
        {
            return GetMemberAttributes(GetMember(action), predicate);
        }

        public static TAttributeType GetMemberAttribute<TType, TAttributeType>(
            Expression<Func<TType, object>> action,
            Func<TAttributeType, bool> predicate = null)
            where TAttributeType : Attribute
        {
            return GetMemberAttribute(GetMember(action), predicate);
        }

        public static bool HasMemberAttribute<TType, TAttributeType>(Expression<Func<TType, object>> action, Func<TAttributeType, bool> predicate = null) where TAttributeType : Attribute
        {
            return GetMemberAttribute(GetMember(action), predicate) != null;
        }
        
        public static List<Attribute> GetMemberAttributes(this MemberInfo memberInfo)
        {
            return
                LockAndGetAttributes(memberInfo, mi => ((MemberInfo)mi).GetCustomAttributes(true));
        }

        public static List<TAttributeType> GetMemberAttributes<TAttributeType>(this MemberInfo memberInfo, Func<TAttributeType, bool> predicate = null) where TAttributeType : Attribute
        {
            return
                GetMemberAttributes(memberInfo)
                    .Where<Attribute, TAttributeType>()
                    .Where(attr => predicate == null || predicate(attr))
                    .ToList();
        }

        public static TAttributeType GetMemberAttribute<TAttributeType>(this MemberInfo memberInfo, Func<TAttributeType, bool> predicate = null) where TAttributeType : Attribute
        {
            return
                GetMemberAttributes(memberInfo, predicate)
                    .FirstOrDefault();
        }

        public static bool HasMemberAttribute<TAttributeType>(this MemberInfo memberInfo, Func<TAttributeType, bool> predicate = null) where TAttributeType : Attribute
        {
            return
                memberInfo.GetMemberAttribute(predicate) != null;
        }

        private static IEnumerable<TType> Where<X, TType>(this IEnumerable<X> list)
        {
            return
                list
                    .Where(item => item is TType)
                    .Cast<TType>();
        }

        private static List<Attribute> LockAndGetAttributes(object key, Func<object, object[]> retrieveValue)
        {
            return
                LockAndGet(AttributeCache, key, mi => retrieveValue(mi).Cast<Attribute>().ToList());
        }

        private static TValue LockAndGet<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> retrieveValue)
        {
            TValue value;
            lock (dictionary)
            {
                if (dictionary.TryGetValue(key, out value))
                {
                    return value;
                }
            }

            value = retrieveValue(key);

            lock (dictionary)
            {
                if (dictionary.ContainsKey(key) == false)
                {
                    dictionary.Add(key, value);
                }

                return value;
            }
        }

        private static MemberInfo GetMember<T>(Expression<Func<T, object>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression != null)
            {
                return memberExpression.Member;
            }

            var unaryExpression = expression.Body as UnaryExpression;

            if (unaryExpression != null)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;

                if (memberExpression != null)
                {
                    return memberExpression.Member;
                }

                var methodCall = unaryExpression.Operand as MethodCallExpression;
                if (methodCall != null)
                {
                    return methodCall.Method;
                }
            }

            return null;
        }
    }
}