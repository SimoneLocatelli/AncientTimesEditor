using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using FluentChecker;
using System;

namespace Editor.ScriptManager
{
    /// <summary>
    ///     Class ScriptSerializer used to write in a script file on disk.
    /// </summary>
    public class ScriptSerializer : IScriptSerializer
    {
        private readonly IFileWriter fileWriter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ScriptSerializer" /> class.
        /// </summary>
        /// <param name="fileWriter">The file writer.</param>
        public ScriptSerializer(IFileWriter fileWriter)
        {
            Check.IfIsNull(fileWriter).Throw<ArgumentNullException>(() => fileWriter);
            this.fileWriter = fileWriter;
        }

        /// <summary>
        ///     Saves the specified script to disk.
        /// </summary>
        /// <param name="script"> The script file. </param>
        /// <param name="content"> The content to save. </param>
        public void Serialize(IFile script, string content)
        {
            Check.IfIsNull(script).Throw<ArgumentNullException>(() => script);
            Check.IfIsNullOrWhiteSpace(script.FullPath).Throw<ArgumentException>(script.FullPath);
            Check.IfIsNull(content).Throw<ArgumentNullException>(() => content);
            fileWriter.Write(content, script.FullPath);
        }
    }
}