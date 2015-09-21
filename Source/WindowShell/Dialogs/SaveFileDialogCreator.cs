using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dependencies;
using FluentChecker;
using Microsoft.Win32;
using System;
using System.Globalization;

namespace Editor.WindowShell.Dialogs
{
    /// <summary>
    ///     Create save file dialog for a  file
    /// </summary>
    public class SaveFileDialogCreator : ISaveFileDialogCreator
    {
        public ISaveFileDialog Create(string description, string extension)
        {
            Check.IfIsNull(description).Throw<ArgumentNullException>(() => description);
            Check.IfIsNullOrWhiteSpace(extension).Throw<ArgumentNullException>(() => extension);

            var saveFileDialog = new SaveFileDialog
            {
                Filter = string.Format(CultureInfo.CurrentCulture,
                    "{0} (*.{1})|*.{1}", description, extension)
            };

            return new EditorSaveFileDialog(saveFileDialog);
        }

        public ISaveFileDialog Create(IFile file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);
            Check.IfIsNull(file.FileInfo).Throw<ArgumentNullException>(() => file.FileInfo);

            return Create(file.FileInfo.Description, file.FileInfo.Extension);
        }
    }
}