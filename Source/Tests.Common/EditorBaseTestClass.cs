using FluentChecker;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestInjector;

namespace Tests.Common
{
    /// <summary>
    ///     Provides common features for all the
    ///     test classes for the Editor application/
    /// </summary>
    [TestClass]
    public abstract class EditorBaseTestClass : BaseTestClass
    {
        /// <summary>
        ///     Wraps the test instructions inside a Shims block.
        /// </summary>
        /// <param name="testAction">The method containing the tests instructions.</param>
        protected static void TestWithShims(Action testAction)
        {
            Check.IfIsNull(testAction).Throw<ArgumentNullException>(() => testAction);

            using (ShimsContext.Create())
            {
                testAction();
            }
        }

        /// <summary>
        ///     Configures the dependencies inside the Dependency Resolver.
        /// </summary>
        /// <param name="dependencyResolver">The dependency resolver.</param>
        protected virtual void ConfigureDependencies(IDependencyResolver dependencyResolver)
        {
        }
    }
}