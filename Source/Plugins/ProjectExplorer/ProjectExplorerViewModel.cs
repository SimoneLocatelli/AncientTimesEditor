using Editor.FileSystem.Dependencies.Events;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.ProjectExplorer.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace Editor.ProjectExplorer
{
    /// <summary>
    ///     The View Model for the Project Explorer control
    /// </summary>
    public class ProjectExplorerViewModel : BaseViewModel, IProjectExplorerViewModel
    {
        private readonly IEnumerable<IProjectExplorerItem> fixedProjectExplorerItems;

        private readonly ObservableCollection<ProjectExplorerItemWrapper> items =
            new ObservableCollection<ProjectExplorerItemWrapper>();

        private readonly IProjectExplorerItemFactory projectExplorerItemFactory;

        /// <summary>
        ///     Gets or sets the items contained in the Project Explorer treeview.
        /// </summary>
        /// <value> The items. </value>
        public IEnumerable<IProjectExplorerItem> Items
        {
            get { return items; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectExplorerViewModel" /> class.
        /// </summary>
        /// <param name="fixedProjectExplorerItems">The fixed project explorer items.</param>
        /// <param name="projectLoader">The project loader.</param>
        /// <param name="projectExplorerItemFactory">The project explorer item factory.</param>
        [ImportingConstructor]
        public ProjectExplorerViewModel(
            [ImportMany(ImportConstants.FixedProjectExplorerItemKey)] IEnumerable<IProjectExplorerItem>
                fixedProjectExplorerItems,
            IProjectLoader projectLoader,
            IProjectExplorerItemFactory projectExplorerItemFactory)
        {
            Check.IfIsNull(fixedProjectExplorerItems).Throw<ArgumentNullException>(() => fixedProjectExplorerItems);
            Check.IfIsNull(projectLoader).Throw<ArgumentNullException>(() => projectLoader);
            Check.IfIsNull(projectExplorerItemFactory).Throw<ArgumentNullException>(() => projectExplorerItemFactory);

            this.fixedProjectExplorerItems = fixedProjectExplorerItems;
            this.projectExplorerItemFactory = projectExplorerItemFactory;

            projectLoader.ProjectLoaded += OnProjectLoad;
        }

        private void AddProjectExplorerItem(IEnumerable<IProjectExplorerItem> projectExplorerItems)
        {
            projectExplorerItems.ToList().ForEach(AddProjectExplorerItem);
        }

        private void AddProjectExplorerItem(IProjectExplorerItem projectExplorerItem)
        {
            items.Add(new ProjectExplorerItemWrapper(projectExplorerItem));
        }

        /// <summary>
        ///     Called when a project has beeen loaded.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        ///     The <see cref="ProjectLoadedEventArgs" /> instance containing the event data.
        /// </param>
        private void OnProjectLoad(object sender, ProjectLoadedEventArgs e)
        {
            items.Clear();

            AddProjectExplorerItem(fixedProjectExplorerItems.ToList());
            AddProjectExplorerItem(projectExplorerItemFactory.Create(e.Project));
        }
    }
}