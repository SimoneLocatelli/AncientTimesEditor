namespace Editor.FileSystem.FileInfo
{
    public class ProjectFileInfo : BaseFileInfo<ProjectFileInfo>
    {
        /// <summary>
        ///     Gets the default name of the file to use when a new item of this type is being created.
        /// </summary>
        /// <value> The default name of the file. </value>
        public override string DefaultFileName
        {
            get { return Resources.EntityProjectDefaultFileName; }
        }

        /// <summary>
        ///     Gets the description of the file type.
        /// </summary>
        /// <value> The description. </value>
        public override string Description
        {
            get { return Resources.EntityProjectDescription; }
        }

        /// <summary>
        ///     Gets the file extension.
        /// </summary>
        /// <value> The extension. </value>
        public override string Extension
        {
            get { return "atp"; }
        }
    }
}