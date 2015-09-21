using System;

namespace Dependencies
{
    /// <summary>
    ///     It aims to manage the dependency registrations and resolve them when is it requested.
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        ///     Registers the instance in input as implementation for the dependency.
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <param name="implementation"> The implementation. </param>
        void RegisterInstance<TDependency>(TDependency implementation)
            where TDependency : class;

        /// <summary>
        ///     Registers the instance in input as implementation for the dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="implementation">The implementation.</param>
        /// <param name="identifierType">The Type that identify the instance..</param>
        void RegisterInstance<TDependency>(TDependency implementation, Type identifierType)
            where TDependency : class;

        /// <summary>
        ///     Registers the implementation type as implementation for the dependency type.
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <typeparam name="TImplementation"> The type of the implementation. </typeparam>
        void RegisterType<TDependency, TImplementation>()
            where TDependency : class
            where TImplementation : class, TDependency;

        /// <summary>
        ///     Resolves the dependency specified by the generic type.
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <returns> An instance of type TDependency. </returns>
        TDependency Resolve<TDependency>() where TDependency : class;

        /// <summary>
        ///     Resolves the dependency specified by the generic type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="implementationIdentifier">The implementation identifier.</param>
        /// <returns>
        ///     An instance of type TDependency.
        /// </returns>
        TDependency Resolve<TDependency>(string implementationIdentifier) where TDependency : class;

        /// <summary>
        ///     Resolves the dependency specified by the generic type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="identifierType">The Type that identify the instance.</param>
        /// <returns>
        ///     An instance of type TDependency.
        /// </returns>
        TDependency Resolve<TDependency>(Type identifierType) where TDependency : class;
    }
}