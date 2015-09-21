#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using FluentChecker;
using System;

#endregion Usings

namespace Editor.FileSystem.Dependencies.Events
{
    /// <summary>
    ///     Contains the information of the event raised when a project has been loaded.
    /// </summary>
    public class ProjectLoadedEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the project that has been loaded.
        /// </summary>
        /// <value> The project. </value>
        public IProject Project { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectLoadedEventArgs" /> class.
        /// </summary>
        /// <param name="project"> The project. </param>
        public ProjectLoadedEventArgs(IProject project)
        {
            Check.IfIsNull(project).Throw<ArgumentNullException>(() => project);

            Project = project;
        }
    }
}