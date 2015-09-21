using Editor.WindowShell.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.WindowShell
{
    /// <summary>
    ///     Interaction logic for EmptyWindow.xaml
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EmptyWindow : IWindow
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmptyWindow" /> class.
        /// </summary>
        public EmptyWindow()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmptyWindow" /> class.
        /// </summary>
        /// <param name="element">The element.</param>
        public EmptyWindow(UIElement element)
        {
            InitializeComponent();

            SetView(element);
        }

        public void SetView(UIElement element)
        {
            Check.IfIsNull(element).Throw<ArgumentNullException>(() => element);
            Container.Content = element;
        }
    }
}