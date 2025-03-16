using System;
using System.Collections.Generic;
using System.Reflection;

namespace DependencyResolver
{
    internal static class TypeExtensions
    {
#if NETSTANDARD1_0
        internal static IEnumerable<ConstructorInfo> GetConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }
#endif
    }
}
