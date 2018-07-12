namespace System.Xml.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    public static class CustomAttributeProviderExtension
    {
        /// <summary>
        /// Gets the first attribute. Attributes that inherits from typeof(TAttribute) are also retreived (matchExactType is false by default)
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this ICustomAttributeProvider provider) where TAttribute : Attribute
        {
            return provider.GetAttribute<TAttribute>(false);
        }

        /// <summary>
        /// Gets the first attribute and specifiy if attribute must match exactly the requested attribute type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="provider">The provider.</param>
        /// <param name="matchExactType">if set to <c>true</c> [match exact type].</param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this ICustomAttributeProvider provider, bool matchExactType) where TAttribute : Attribute
        {
            TAttribute[] tmp = provider.GetAttributes<TAttribute>(matchExactType);

            if (tmp.Length > 0)
            {
                return tmp[0];
            }
            return null;
        }

        /// <summary>
        /// Gets the attributes. Attributes that inherits from typeof(TAttribute) are also retreived (matchExactType is false by default)
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static TAttribute[] GetAttributes<TAttribute>(this ICustomAttributeProvider provider) where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(provider, false);
        }

        /// <summary>
        /// Gets the attributes and specifiy if attribute must match exactly the requested attribute type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="provider">The provider.</param>
        /// <param name="matchExactType">if set to <c>true</c> [match exact type].</param>
        /// <returns></returns>
        public static TAttribute[] GetAttributes<TAttribute>(this ICustomAttributeProvider provider, bool matchExactType) where TAttribute : Attribute
        {
            Type attributeType = typeof(TAttribute);

            object[] tmp = provider.GetCustomAttributes(attributeType, true);

            var attrs = new List<TAttribute>(tmp.Length);

            foreach (Attribute attr in tmp)
            {
                if (!matchExactType || attr.GetType() == attributeType)
                {
                    attrs.Add((TAttribute)attr);
                }
            }
            return attrs.ToArray();
        }

        /// <summary>
        /// Gets the declaring type of the member.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Type GetDeclaringType(this ICustomAttributeProvider provider)
        {
            Type type = null;

            if (provider is ParameterInfo)
            {
                provider = ((ParameterInfo)provider).Member;
            }

            if (provider is Type)
            {
                type = (Type)provider;
            }
            else if (provider is MemberInfo)
            {
                type = ((MemberInfo)provider).DeclaringType;
            }
            if (type == null)
            {
                throw new NotSupportedException("GetReflectedType doesn't know " + provider);
            }

            return type;
        }

        /// <summary>
        /// Gets the declaring type of the member.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Type GetReflectedType(this ICustomAttributeProvider provider)
        {
            Type type = null;

            if (provider is ParameterInfo)
            {
                provider = ((ParameterInfo)provider).Member;
            }
            if (provider is Type)
            {
                type = (Type)provider;
            }
            else if (provider is MemberInfo)
            {
                type = ((MemberInfo)provider).DeclaringType;
            }
            if (type == null)
            {
                throw new NotSupportedException("GetReflectedType doesn't know " + provider);
            }

            return type;
        }

        /// <summary>
        /// Gets the type of the member.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Type GetMemberType(this ICustomAttributeProvider provider)
        {
            Type type = null;

            if (provider is PropertyInfo)
            {
                type = ((PropertyInfo)provider).PropertyType;
            }
            else if (provider is FieldInfo)
            {
                type = ((FieldInfo)provider).FieldType;
            }
            else if (provider is Type)
            {
                type = ((Type)provider);
            }
            else if (provider is EventInfo)
            {
                type = ((EventInfo)provider).EventHandlerType;
            }
            else if (provider is ParameterInfo)
            {
                type = ((ParameterInfo)provider).ParameterType;
            }

            return type;
        }

        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static object GetDefaultValue(this ICustomAttributeProvider provider)
        {
            var defaultValueAttribute = provider.GetAttribute<DefaultValueAttribute>();

            if (defaultValueAttribute != null)
            {
                return defaultValueAttribute.Value;
            }

            Type type = provider.GetMemberType();

            if (type != null)
            {
                defaultValueAttribute = type.GetAttribute<DefaultValueAttribute>();
                if (defaultValueAttribute != null)
                {
                    return defaultValueAttribute.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the converter.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static TypeConverter GetConverter(this ICustomAttributeProvider provider)
        {
            var converterAttribute = provider.GetAttribute<TypeConverterAttribute>();
            try
            {
                if (converterAttribute != null)
                {
                    Type t = Type.GetType(converterAttribute.ConverterTypeName, true, true);
                    return (TypeConverter)Activator.CreateInstance(t, true);
                }
            }
            catch
            {
                Type type = provider.GetMemberType();

                if (type != null)
                {
                    return TypeDescriptor.GetConverter(type);
                }
            }
            return null;
        }
    }
}
