using Editor.FileSystem.Dependencies.FileEntities;
using System.Windows;

namespace Editor.WindowShell.Dependencies.ScriptEditor
{
    /// <summary>
    ///     The script editor control.
    /// </summary>
    public interface IScriptEditor
    {
        /// <summary>
        ///     Gets the <see cref="UIElement" /> control.
        /// </summary>
        /// <value> The control. </value>
        UIElement Control { get; }

        /// <summary>
        ///     Sets the script file.
        /// </summary>
        /// <param name="file">The file.</param>
        void SetScriptFile(IFile file);
    }
}