using Editor.WindowShell.Dependencies;
using System;
using System.ComponentModel;

namespace Editor.ItemEditor.Tests.MockData
{
    public class SpyWindow : IWindow
    {
        private bool isLoaded;

        public bool IsLoaded
        {
            get { return isLoaded; }
        }

        public bool ShowHasBeenCalled { get; private set; }

        public event EventHandler Closed;

        public event CancelEventHandler Closing;

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            ShowHasBeenCalled = true;
        }

        public bool? ShowDialog()
        {
            ShowHasBeenCalled = true;

            return false;
        }
    }
}