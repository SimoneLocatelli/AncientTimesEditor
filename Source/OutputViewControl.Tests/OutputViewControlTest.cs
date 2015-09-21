using Editor.OutputView.Dependencies;
using Editor.OutputView.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutputView;
using Tests.Common;

namespace Editor.OutputView.Tests
{
    [TestClass]
    public class OutputViewControlTest : EditorBaseTestClass<OutputViewControl>
    {
        [TestMethod]
        public void WhenInstantiatedItWillContainDefaultValues()
        {
            Test(resolver =>
            {
                var outputViewControl = ResolveClassToTest(resolver);
                Assert.AreEqual(outputViewControl, outputViewControl.Control);
                Assert.IsNotNull(outputViewControl.DataContext);
                Assert.IsInstanceOfType(outputViewControl.DataContext, typeof (StubIOutputViewControlViewModel));
            });
        }

        [TestMethod]
        public void WhenLogMessageItWillCallViewModelMethod()
        {
            Test(resolver =>
            {
                var hasLogMethodBeenCalled = false;

                resolver.RegisterInstance<IOutputViewControlViewModel>(new StubIOutputViewControlViewModel
                {
                    LogStringString = (s, s1) => hasLogMethodBeenCalled = true
                });

                var outputViewControl = ResolveClassToTest(resolver);
                outputViewControl.Log("TestCategory", "Test");

                Assert.IsTrue(hasLogMethodBeenCalled);
            });
        }

        protected override void ConfigureDependencies(IDependencyResolver dependencyResolver)
        {
            base.ConfigureDependencies(dependencyResolver);
            dependencyResolver.RegisterType<IOutputViewControlViewModel, StubIOutputViewControlViewModel>();
        }
    }
}