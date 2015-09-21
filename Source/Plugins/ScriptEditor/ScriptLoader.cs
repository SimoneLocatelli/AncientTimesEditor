using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.FileSystem.FileEntities;
using FluentChecker;
using System;
using Utils;

namespace Editor.ScriptManager
{
    /// <summary>
    ///     Class ScriptLoader used to locate and load a script from a file on disk.
    /// </summary>
    public class ScriptLoader : IScriptLoader
    {
        private readonly IFileReader fileReader;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ScriptLoader" /> class.
        /// </summary>
        /// <param name="fileReader">The file reader.</param>
        public ScriptLoader(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        /// <summary>
        ///     Reads the content of the specified script file.
        /// </summary>
        /// <param name="file">The file containing the script.</param>
        /// <returns>A string containing the script.</returns>
        public string LoadContent(IFile file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);
            Check.IfIsNotOfType<Script>(file)
                .Throw<ArgumentException>(ArgumentExceptionMessagesFactory.InstanceIsNotExpectedType<Script>());
            return fileReader.Read(file.FullPath);
        }
    }
}