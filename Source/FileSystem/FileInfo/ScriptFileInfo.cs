namespace Editor.FileSystem.FileInfo
{
    /// <summary>
    ///     Basic info for a script file.
    /// </summary>
    public class ScriptFileInfo : BaseFileInfo<ScriptFileInfo>
    {
        /// <summary>
        ///     Gets the default name of the file to use when a new item of this type is being created.
        /// </summary>
        /// <value> The default name of the file. </value>
        public override string DefaultFileName
        {
            get { return Resources.EntityScriptDefaultFileName; }
        }

        /// <summary>
        ///     Gets the description of the file type.
        /// </summary>
        /// <value> The description. </value>
        public override string Description
        {
            get { return Resources.EntityScriptDescription; }
        }

        /// <summary>
        ///     Gets the file extension.
        /// </summary>
        /// <value> The extension. </value>
        public override string Extension
        {
            get { return "lua"; }
        }
    }
}