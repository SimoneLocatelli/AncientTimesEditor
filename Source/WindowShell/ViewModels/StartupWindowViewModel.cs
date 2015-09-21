using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.Settings.Dependencies;
using Editor.WindowShell.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.WindowShell.ViewModels
{
    public class StartupWindowViewModel : BaseViewModel, IStartupWindowViewModel
    {
        private readonly IProjectLoader projectLoader;
        private readonly IFileOpener<IProject> projectOpener;
        private readonly IEnumerable<IRecentProject> recentProjects;
        private IRecentProject selctedProject;

        public IWindow ParentWindow { get; set; }

        public IEnumerable<IRecentProject> RecentProjects
        {
            get { return recentProjects; }
        }

        public IRecentProject SelectedProject
        {
            get { return selctedProject; }
            set
            {
                SetProperty(ref selctedProject, value);
                OpenSelectedProject();
            }
        }

        [ImportingConstructor]
        public StartupWindowViewModel(ISettingsSerializer settingsSerializer,
            IProjectLoader projectLoader,
            IFileOpener<IProject> projectOpener)
        {
            Check.IfIsNull(settingsSerializer).Throw<ArgumentNullException>(() => settingsSerializer);
            Check.IfIsNull(projectLoader).Throw<ArgumentNullException>(() => projectLoader);
            Check.IfIsNull(projectOpener).Throw<ArgumentNullException>(() => projectOpener);

            this.projectLoader = projectLoader;
            this.projectOpener = projectOpener;
            var settings = settingsSerializer.Read();
            recentProjects = settings.RecentProjects;
        }

        public void OpenSelectedProject()
        {
            if (SelectedProject == null) return;

            var project = projectOpener.Open(SelectedProject.FullPath);

            projectLoader.Load(project);

            if (ParentWindow != null) ParentWindow.Close();
        }
    }
}