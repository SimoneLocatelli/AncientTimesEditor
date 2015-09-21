using Editor.FileSystem.Dependencies.Events;
using Editor.FileSystem.Dependencies.FileEntities;
using System;
using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     Loads a project, notifying the operation
    /// </summary>
    [InheritedExport]
    public interface IProjectLoader
    {
        /// <summary>
        ///     Gets the reference to the currently loaded project.
        /// </summary>
        /// <value> The currently loaded project. </value>
        IProject CurrentProject { get; }

        /// <summary>
        ///     Occurs when a project is loaded.
        /// </summary>
        event EventHandler<ProjectLoadedEventArgs> ProjectLoaded;

        /// <summary>
        ///     Loads the specified project, and after that, notifies the loading.
        /// </summary>
        /// <param name="project"> The project. </param>
        void Load(IProject project);
    }
}