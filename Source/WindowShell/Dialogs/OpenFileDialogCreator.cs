using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dependencies;
using FluentChecker;
using Microsoft.Win32;
using System;
using System.Globalization;

namespace Editor.WindowShell.Dialogs
{
    /// <summary>
    ///     Create open file dialog for a  file
    /// </summary>
    public class OpenFileDialogCreator : IOpenFileDialogCreator
    {
        public IOpenFileDialog Open(string description, string extension)
        {
            Check.IfIsNull(description).Throw<ArgumentNullException>(() => description);
            Check.IfIsNullOrWhiteSpace(extension).Throw<ArgumentException>(() => extension);

            var openFileDialog = new OpenFileDialog
            {
                Filter = string.Format(CultureInfo.CurrentCulture,
                    "{0} (*.{1})|*.{1}", description, extension)
            };

            return new EditorOpenFileDialog(openFileDialog);
        }

        public IOpenFileDialog Open(IFile file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);
            Check.IfIsNull(file.FileInfo).Throw<ArgumentNullException>(() => file.FileInfo);

            return Open(file.FileInfo.Description, file.FileInfo.Extension);
        }
    }
}