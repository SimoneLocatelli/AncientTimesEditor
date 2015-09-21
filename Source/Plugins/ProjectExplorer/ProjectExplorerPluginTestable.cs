#region Usings

using Editor.PluginsTester.Dependencies;
using Editor.ProjectExplorer.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

#endregion Usings

namespace Editor.ProjectExplorer
{
    /// <summary>
    ///     Plugin used to test the Project Explorer from the Plugin Tester
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProjectExplorerPluginTestable : IPluginTestable
    {
        /// <summary>
        ///     Gets the content to display in the Details view.
        /// </summary>
        /// <value>
        ///     The content.
        /// </value>
        public UIElement Content { get; private set; }

        /// <summary>
        ///     Gets the name of the plugin (or of the feature to test).
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name
        {
            get { return "Project Explorer"; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectExplorerPluginTestable" /> class.
        /// </summary>
        /// <param name="projectExplorerView">The project explorer view.</param>
        [ImportingConstructor]
        public ProjectExplorerPluginTestable(IProjectExplorerView projectExplorerView)
        {
            Check.IfIsNull(projectExplorerView).Throw<ArgumentNullException>(() => projectExplorerView);

            Content = projectExplorerView.Control;
        }
    }
}