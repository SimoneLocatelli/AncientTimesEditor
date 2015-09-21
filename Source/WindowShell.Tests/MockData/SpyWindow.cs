using System;
using System.ComponentModel;
using Editor.WindowShell.Dependencies;

namespace Editor.WindowShell.Tests.MockData
{
    class SpyWindow : IWindow
    {
        private bool isLoaded;

        public bool HasClosedBeenCalled { get; private set; }

        public bool IsLoaded
        {
            get { return isLoaded; }
        }

        public event EventHandler Closed;

        public event CancelEventHandler Closing;

        public void Close()
        {
            HasClosedBeenCalled = true;
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public bool? ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}