#region Usings

using Editor.FileSystem.Dependencies.FileEntities;
using System.ComponentModel.Composition;

#endregion Usings

namespace Editor.FileSystem.Dependencies.FileManagers
{
    /// <summary>
    ///     A serializaer for the <see cref="IScript" /> entity
    /// </summary>
    [InheritedExport]
    public interface IScriptSerializer
    {
        /// <summary>
        ///     Saves the specified script to disk.
        /// </summary>
        /// <param name="script">The script.</param>
        /// <param name="content">The content.</param>
        void Serialize(IFile script, string content);
    }
}