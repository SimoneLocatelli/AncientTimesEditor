using Editor.OutputView.Dependencies;
using Editor.OutputView.Dependencies.Fakes;
using Editor.WpfCommonLibrary.Dependencies.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutputView;
using Tests.Common;

namespace Editor.OutputView.Tests
{
    [TestClass]
    public class OutputViewControlTest : EditorBaseTestClass
    {
        [TestMethod]
        public void WhenInstantiatedItWillContainDefaultValues()
        {
            var outputViewControl = new OutputViewControl(new StubIBindingErrorListener(), new StubIOutputViewControlViewModel());
            Assert.IsNotNull(outputViewControl.DataContext);
            Assert.IsInstanceOfType(outputViewControl.DataContext, typeof (StubIOutputViewControlViewModel));
        }

        [TestMethod]
        public void WhenLogMessageItWillCallViewModelMethod()
        {
            var hasLogMethodBeenCalled = false;

            var outputViewControl = new OutputViewControl(new StubIBindingErrorListener(),
                new StubIOutputViewControlViewModel
                {
                    LogStringString = (s, s1) => hasLogMethodBeenCalled = true
                });
            outputViewControl.Log("TestCategory", "Test");

            Assert.IsTrue(hasLogMethodBeenCalled);
        }

        protected override void ConfigureDependencies(IDependencyResolver dependencyResolver)
        {
            base.ConfigureDependencies(dependencyResolver);
            dependencyResolver.RegisterType<IOutputViewControlViewModel, StubIOutputViewControlViewModel>();
        }
    }
}