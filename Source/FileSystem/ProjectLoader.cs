using Editor.FileSystem.Dependencies.Events;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.Logging.Dependencies;
using Editor.Settings.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.FileSystem
{
    /// <summary>
    ///     Loads a project, notifying the operation
    /// </summary>
    public class ProjectLoader : IProjectLoader
    {
        private readonly IEditorLogger logger;
        private readonly IObjectDumper objectDumper;
        private readonly ISettingsSerializer settingsSerializer;

        public IProject CurrentProject { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectLoader" /> class.
        /// </summary>
        [ImportingConstructor]
        public ProjectLoader(IEditorLogger logger, IObjectDumper objectDumper, ISettingsSerializer settingsSerializer)
        {
            Check.IfIsNull(logger).Throw<ArgumentNullException>(() => logger);
            Check.IfIsNull(objectDumper).Throw<ArgumentNullException>(() => objectDumper);
            this.logger = logger;
            this.objectDumper = objectDumper;
            this.settingsSerializer = settingsSerializer;
        }

        /// <summary>
        ///     Occurs when a project is loaded.
        /// </summary>
        public event EventHandler<ProjectLoadedEventArgs> ProjectLoaded;

        /// <summary>
        ///     Loads the specified project, and after that, notifies the loading.
        /// </summary>
        /// <param name="project"> The project. </param>
        public void Load(IProject project)
        {
            logger.Log(Resources.ProjectLoaderLoggerCategory, "The loaded project is changed. Current value: {0}.",
                objectDumper.Dump(project));

            CurrentProject = project;

            if (ProjectLoaded != null)
            {
                ProjectLoaded(this, new ProjectLoadedEventArgs(project));

                UpdateRecentOpenedProjectsList(project);
            }
        }

        private void UpdateRecentOpenedProjectsList(IProject project)
        {
            var settings = settingsSerializer.Read();

            settings.RecentProjects.Add(project);

            settingsSerializer.Save();
        }
    }
}