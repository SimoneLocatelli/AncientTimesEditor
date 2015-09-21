using FluentChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests.Common
{
    /// <summary>
    ///     Retrieves information about the properties contained using the Reflection
    /// </summary>
    public static class PropertiesNavigator
    {
        /// <summary>
        ///     Gets the public properties from the input type.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPublicProperties<TSource>()
        {
            return GetPublicProperties(typeof(TSource));
        }

        /// <summary>
        ///     Gets the public properties from the input type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPublicProperties(Type type)
        {
            Check.IfIsNull(type).Throw<ArgumentNullException>(() => type);

            if (!type.IsInterface) return GetAllPublicProperties(type);

            var propertyInfos = new List<PropertyInfo>();

            var considered = new List<Type>();
            var queue = new Queue<Type>();
            considered.Add(type);
            queue.Enqueue(type);

            while (queue.Any())
            {
                var subType = queue.Dequeue();

                var interfaces = GetInterfaces(subType, considered);

                considered.AddRange(interfaces);
                interfaces.ForEach(queue.Enqueue);

                var typeProperties = GetAllPublicProperties(subType);

                propertyInfos.AddRange(GetPropertiesNotConsideredYet(typeProperties, propertyInfos));
            }

            return propertyInfos.ToList();
        }

        private static IEnumerable<PropertyInfo> GetAllPublicProperties(IReflect subType)
        {
            return subType.GetProperties(
                BindingFlags.FlattenHierarchy
                | BindingFlags.Public
                | BindingFlags.Instance);
        }

        private static List<Type> GetInterfaces(Type subType, List<Type> considered)
        {
            return subType.GetInterfaces()
                .Where(i => !InterfaceHasBeenAlreadyConsidered(considered, i)).ToList();
        }

        private static IEnumerable<PropertyInfo> GetPropertiesNotConsideredYet(IEnumerable<PropertyInfo> typeProperties,
            List<PropertyInfo> propertyInfos)
        {
            return typeProperties.Where(x => !propertyInfos.Contains(x));
        }

        private static bool InterfaceHasBeenAlreadyConsidered(List<Type> considered, Type subInterface)
        {
            return considered.Contains(subInterface);
        }
    }
}