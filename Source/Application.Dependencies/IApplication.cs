using System;
using System.ComponentModel.Composition;

namespace Editor.Application.Dependencies
{
    /// <summary>
    ///     Provides information about the active application
    ///     and its life
    /// </summary>
    [InheritedExport]
    public interface IApplication
    {
        /// <summary>
        ///     Gets the installation path of the application.
        ///     It corresponds of the location path of the executable.
        /// </summary>
        /// <value>
        ///     The installation path of the application.
        /// </value>
        string InstallationPath { get; }

        /// <summary>
        ///     Occurs when the application is being closed
        /// </summary>
        event EventHandler OnApplicationClose;
    }
}