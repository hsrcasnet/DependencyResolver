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
        //store for dependency maps  
        private readonly Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();

        //this method calls the next one - we use this one publicly just because its syntax is cooler  
        public T Resolve<T>()
        {
            return (T)this.Resolve(typeof(T));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolvedType;
            try
            {
                //check if we have a configured map  
                resolvedType = this.dependencyMap[typeToResolve];
            }
            catch
            {
                throw new Exception($"Could not resolve {typeToResolve.FullName}");
            }

            //get the constructor and then the parameters  
            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();

            // In the case of parameterless constructor  
            if (!constructorParameters.Any())
            {
                //return an instance of the resolved type  
                return Activator.CreateInstance(resolvedType);
            }

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

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            this.dependencyMap.Add(typeof(TInterface), typeof(TImplementation));
        }
    }
}