using System.ComponentModel.Composition;

namespace Editor.FileSystem.Dependencies.Utils
{
    /// <summary>
    ///     Provides utilities to manage the system paths.
    /// </summary>
    [InheritedExport]
    public interface IPathUtils
    {
        /// <summary>
        ///     Gets the extension removing the dot if it's the first character.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        string GetExtensionWithoutStartingDot(string filePath);
    }
}