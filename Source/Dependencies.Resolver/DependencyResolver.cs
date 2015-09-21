using FluentChecker;
using Microsoft.Practices.Unity;
using System;
using System.Composition;

namespace Dependencies.Resolver
{
    /// <summary>
    ///     It aims to manage the dependency registrations and resolve them when is it requested.
    /// </summary>
    [Export(typeof (IDependencyResolver))]
    public class DependencyResolver : IDependencyResolver, UnitTestInjector.IDependencyResolver
    {
        private readonly IUnityContainer container;

        public DependencyResolver(IUnityContainer container)
        {
            this.container = container;
        }

        /// <summary>
        ///     Registers the instance in input as implementation for the dependency.
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <param name="implementation"> The implementation. </param>
        public void RegisterInstance<TDependency>(TDependency implementation) where TDependency : class
        {
            Check.IfIsNull(implementation).Throw<ArgumentNullException>(() => implementation);
            container.RegisterInstance(implementation);
        }

        /// <summary>
        ///     Registers the instance in input as implementation for the dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="implementation">The implementation.</param>
        /// <param name="identifierType">The Type that identify the instance.</param>
        public void RegisterInstance<TDependency>(TDependency implementation, Type identifierType)
            where TDependency : class
        {
            Check.IfIsNull(implementation).Throw<ArgumentNullException>(() => implementation);
            container.RegisterInstance(ExtractIdentifierStringFromType(identifierType), implementation);
        }

        /// <summary>
        ///     Registers the implementation type as implementation for the dependency type.
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <typeparam name="TImplementation"> The type of the implementation. </typeparam>
        public void RegisterType<TDependency, TImplementation>()
            where TDependency : class
            where TImplementation : class, TDependency
        {
            container.RegisterType<TDependency, TImplementation>();
        }

        /// <summary>
        ///     Resolves the dependency specified by the generic type.
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <returns> An instance of type TDependency. </returns>
        public TDependency Resolve<TDependency>() where TDependency : class
        {
            return container.Resolve<TDependency>();
        }

        /// <summary>
        ///     Resolves the dependency specified by the generic type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="identifierType">The Type that identify the instance.</param>
        /// <returns>
        ///     An instance of type TDependency.
        /// </returns>
        public TDependency Resolve<TDependency>(Type identifierType) where TDependency : class
        {
            Check.IfIsNull(identifierType).Throw<ArgumentNullException>(() => identifierType);
            return Resolve<TDependency>(ExtractIdentifierStringFromType(identifierType));
        }

        /// <summary>
        ///     Resolves the dependency specified by the generic type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="implementationIdentifier">The implementation identifier.</param>
        /// <returns>
        ///     An instance of type TDependency.
        /// </returns>
        public TDependency Resolve<TDependency>(string implementationIdentifier) where TDependency : class
        {
            Check.IfIsNull(implementationIdentifier).Throw<ArgumentNullException>(() => implementationIdentifier);
            return container.Resolve<TDependency>(implementationIdentifier);
        }

        private static string ExtractIdentifierStringFromType(Type type)
        {
            return type.FullName;
        }
    }
}