using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Diagnostics.Fakes;
using Tests.Common;

namespace WpfCommonLibrary.Tests
{
    [TestClass]
    public class BindingErrorListenerTest : EditorBaseTestClass
    {
        public void Listen()
        {
            var fakeTraceSource = new FakeTraceSource("Test");
            ShimPresentationTraceSources.DataBindingSourceGet = () => fakeTraceSource;

            var bindingErrorListener = new BindingErrorListener();

            var step = 0;

            bindingErrorListener.Listen(s =>
            {
                if (step == 0)
                {
                    Assert.AreEqual("Write", s);
                    step++;
                }
                else
                {
                    Assert.AreEqual("Write Line", s);
                }
            });
            bindingErrorListener.Write("Write");
            bindingErrorListener.WriteLine("Write Line");
        }

        [TestMethod]
        public void ListenWithNullAction()
        {
            TestExpectedArgumentException<ArgumentNullException>(
                () => new BindingErrorListener().Listen(null), "action");
        }

        private class FakeTraceSource : TraceSource
        {
            public FakeTraceSource(string name)
                : base(name)
            {
            }
        }
    }
}