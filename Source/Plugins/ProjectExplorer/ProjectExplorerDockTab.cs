using Editor.DockSystem.Dependencies;
using Editor.ProjectExplorer.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.ProjectExplorer
{
    /// <summary>
    ///     Dock tab that wraps the Project Explorer control.
    /// </summary>
    [Export(ImportsConstants.DockSystemTools, typeof (IDockTab))]
    public class ProjectExplorerDockTab : BaseDockTab
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectExplorerDockTab" /> class.
        /// </summary>
        /// <param name="projectExplorerView">The project explorer view.</param>
        [ImportingConstructor]
        public ProjectExplorerDockTab(IProjectExplorerView projectExplorerView)
        {
            Check.IfIsNull(projectExplorerView).Throw<ArgumentNullException>(() => projectExplorerView);

            Control = projectExplorerView.Control;
            Title = Resources.ProjectExplorerHeader;
        }
    }
}