using Editor.ProjectExplorer.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;

namespace Editor.ProjectExplorer
{
    /// <summary>
    ///     Interaction logic for ProjectExplorer.xaml
    /// </summary>
    [Export]
    public partial class ProjectExplorerView : IProjectExplorerView
    {
        /// <summary>
        ///     Gets the <see cref="UIElement" /> control.
        /// </summary>
        /// <value> The control. </value>
        [ExcludeFromCodeCoverage]
        public UIElement Control
        {
            get { return this; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectExplorerView" /> class.
        /// </summary>
        /// <param name="projectExplorerViewModel">The project explorer view model.</param>
        [ImportingConstructor]
        public ProjectExplorerView(IProjectExplorerViewModel projectExplorerViewModel)
        {
            Check.IfIsNull(projectExplorerViewModel).Throw<ArgumentNullException>(() => projectExplorerViewModel);

            InitializeComponent();

            DataContext = projectExplorerViewModel;
        }
    }
}