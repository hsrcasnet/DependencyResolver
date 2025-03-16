using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DependencyResolver
{
    internal static class TypeExtensions
    {
        internal static IEnumerable<ConstructorInfo> GetConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }
    }
}
