using Editor.FileSystem.Dependencies;
using Editor.FileSystem.FileInfo;

namespace Editor.FileSystem.FileEntities
{
    /// <summary>
    ///     Representation of a script file.
    /// </summary>
    public class Script : FileBase
    {
        private readonly IFileInfo scriptFileInfo = new ScriptFileInfo();

        public override IFileInfo FileInfo
        {
            get { return scriptFileInfo; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Script" /> class.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <param name="path"> The path. </param>
        public Script(string name, string path)
            : base(name, path)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Script" /> class.
        /// </summary>
        /// <param name="fullName"> The file full name. </param>
        public Script(string fullName)
            : base(fullName)
        {
        }
    }
}