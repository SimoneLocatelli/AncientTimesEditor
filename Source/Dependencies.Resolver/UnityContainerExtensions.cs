using FluentChecker;
using Microsoft.Practices.Unity;
using System;

namespace Dependencies.Resolver
{
    public static class UnityContainerExtensions
    {
        public static void RegisterType<TInterface, TImplementation>(this IUnityContainer unityContainer,
            Type identifierType) where TImplementation : TInterface
        {
            Check.IfIsNull(unityContainer).Throw<ArgumentNullException>(() => unityContainer);
            Check.IfIsNull(identifierType).Throw<ArgumentNullException>(() => identifierType);

            unityContainer.RegisterType<TInterface, TImplementation>(identifierType.FullName);
        }
    }
}