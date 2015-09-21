#region Usings

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.WindowShell.Dependencies;

#endregion Usings

namespace Editor.WindowShell.Dialogs.OpenDialog
{
    /// <summary>
    ///     Create the interface to allow to select a Project file.
    /// </summary>
    [Export(typeof (IOpenFileDialog<IProject>))]
    public class ProjectOpenFileDialog : IOpenFileDialog<IProject>
    {
        private readonly IFileFactory fileFactory;
        private readonly IOpenFileDialogCreator openFileDialogCreator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectOpenFileDialog" /> class.
        /// </summary>
        /// <param name="fileFactory">The file factory.</param>
        /// <param name="openFileDialogCreator">The open file dialog creator.</param>
        [ImportingConstructor]
        public ProjectOpenFileDialog(IFileFactory fileFactory, IOpenFileDialogCreator openFileDialogCreator)
        {
            this.fileFactory = fileFactory;
            this.openFileDialogCreator = openFileDialogCreator;
        }

        /// <summary>
        ///     Allows the user to select multiple files.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ShowSelectFileDialog()
        {
            var projectFile = fileFactory.CreateFile<IProject>();
            var dialog = openFileDialogCreator.Open(projectFile);

            dialog.ShowDialog();

            return new Collection<string>
            {
                dialog.FileName
            };
        }
    }
}