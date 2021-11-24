using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyResolver
{
    /// <summary>
    ///     Simplest possible dependency injection container.
    ///     Original source: http://www.pashov.net/code/dependency-injection-hood/
    /// </summary>
    public class Resolver
    {
        // Map interface types to implementation types in a simple dictionary
        private readonly Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();

        /// <summary>
        /// Registers type mappings from <typeparamref name="TInterface"/> to <typeparamref name="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TInterface">The interface type which is later resolved/injected.</typeparam>
        /// <typeparam name="TImplementation">The implementation type to be constructed when a <typeparamref name="TImplementation"/> is resolved.</typeparam>
        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            this.dependencyMap.Add(typeof(TInterface), typeof(TImplementation));
        }

        /// <summary>
        /// Resolves the implementation of the given interface type <typeparamref name="TInterface"/>.
        /// </summary>
        /// <typeparam name="TInterface">The interface type.</typeparam>
        /// <returns>The implementation of <typeparamref name="TInterface"/>.</returns>
        public TInterface Resolve<TInterface>()
        {
            return (TInterface)this.Resolve(typeof(TInterface));
        }

        public object Resolve(Type typeToResolve)
        {
            Type resolvedType;
            try
            {
                // Check if we have a configured type mapping  
                resolvedType = this.dependencyMap[typeToResolve];
            }
            catch
            {
                throw new Exception($"Could not resolve {typeToResolve.FullName}");
            }

            // Get the constructor and then the parameters  
            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();

            // In the case of parameterless constructor  
            if (!constructorParameters.Any())
            {
                // Return an instance of the resolved type  
                var instance = Activator.CreateInstance(resolvedType);
                return instance;
            }
            else
            {
                // In case the typeToResolve has further dependencies
                var dependencies = new List<object>();
                foreach (var constructorParameter in constructorParameters)
                {
                    // Recursively resolve all dependencies
                    var dependency = this.Resolve(constructorParameter.ParameterType);
                    dependencies.Add(dependency);
                }

                var instance = firstConstructor.Invoke(dependencies.ToArray());
                return instance;
            }
        }
    }
}