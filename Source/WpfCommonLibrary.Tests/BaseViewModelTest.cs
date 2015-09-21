using Editor.WpfCommonLibrary.Dependencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Common;

namespace WpfCommonLibrary.Tests
{
    [TestClass]
    public class BaseViewModelTest : EditorBaseTestClass
    {
        [TestMethod]
        public void SetNotWorkingProperties()
        {
            const string parameterName = "propertyName";

            TestExpectedArgumentException<ArgumentException>(
                () => { new FakeViewModel().NotWorkingProperty1 = "Test"; }, parameterName);
            TestExpectedArgumentException<ArgumentException>(
                () => { new FakeViewModel().NotWorkingProperty2 = "Test"; }, parameterName);
            TestExpectedArgumentException<ArgumentException>(
                () => { new FakeViewModel().NotWorkingProperty3 = "Test"; }, parameterName);
        }

        [TestMethod]
        public void WhenPropertyIsNotifiedPropertyChangedEventWillBeCalled()
        {
            var fakeViewModel = new FakeViewModel();
            var hasBeenNotified = false;
            fakeViewModel.PropertyChanged +=
                (sender, args) => { if (args.PropertyName == "NotifiableProperty") hasBeenNotified = true; };

            Assert.IsFalse(hasBeenNotified);

            fakeViewModel.NotifyNotifiableProperty();

            Assert.IsTrue(hasBeenNotified);
        }

        [TestMethod]
        public void WhenSettingPropertyNoPropertyChangedListenersItWillUpdateThePropertyWithNoErrors()
        {
            var fakeViewModel = new FakeViewModel();

            Assert.AreEqual(null, fakeViewModel.WorkingProperty);

            fakeViewModel.WorkingProperty = "Test";

            Assert.AreEqual("Test", fakeViewModel.WorkingProperty);
        }

        private class FakeViewModel : BaseViewModel
        {
            private string notWorkingProperty1;
            private string notWorkingProperty2;
            private string notWorkingProperty3;
            private string workingProperty;

            public string NotifiableProperty
            {
                get { return WorkingProperty; }
            }

            public string NotWorkingProperty1
            {
                set { SetProperty(ref notWorkingProperty1, value, null); }
            }

            public string NotWorkingProperty2
            {
                set { SetProperty(ref notWorkingProperty2, value, " "); }
            }

            public string NotWorkingProperty3
            {
                set { SetProperty(ref notWorkingProperty3, value, string.Empty); }
            }

            public string WorkingProperty
            {
                get { return workingProperty; }
                set { SetProperty(ref workingProperty, value); }
            }

            public void NotifyNotifiableProperty()
            {
                Notify(() => NotifiableProperty);
            }
        }
    }
}