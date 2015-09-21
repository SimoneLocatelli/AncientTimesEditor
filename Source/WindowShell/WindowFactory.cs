using Editor.WindowShell.Dependencies;
using FluentChecker;
using System;
using System.Windows;

namespace Editor.WindowShell
{
    /// <summary>
    ///     Factory class used to creates new Window to contain Views.
    /// </summary>
    public class WindowFactory : IWindowFactory
    {
        public IWindow Create(string title, UIElement view)
        {
            Check.IfIsNull(title).Throw<ArgumentNullException>(() => title);
            Check.IfIsNull(view).Throw<ArgumentNullException>(() => view);

            var window = new EmptyWindow(view) {Title = title};

            return window;
        }
    }
}