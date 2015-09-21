using Editor.WindowShell.Dependencies;
using FluentChecker;
using Microsoft.Win32;
using System;

namespace Editor.WindowShell.Dialogs
{
    /// <summary>
    ///     The Editor save file dialog.
    /// </summary>
    public class EditorSaveFileDialog : ISaveFileDialog
    {
        private readonly SaveFileDialog saveFileDialog;

        /// <summary>
        ///     Gets the name of the file.
        /// </summary>
        /// <value> The name of the file. </value>
        public string FileName
        {
            get { return saveFileDialog.FileName; }
        }

        /// <summary>
        ///     Gets the name of the file.
        /// </summary>
        /// <value> The name of the file. </value>
        public string[] FileNames
        {
            get { return saveFileDialog.FileNames; }
        }

        /// <summary>
        ///     Gets the file filter.
        /// </summary>
        /// <value> The filter. </value>
        public string Filter
        {
            get { return saveFileDialog.Filter; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EditorSaveFileDialog" /> class.
        /// </summary>
        /// <param name="saveFileDialog"> The save file dialog. </param>
        /// <exception cref="System.NotImplementedException"></exception>
        public EditorSaveFileDialog(SaveFileDialog saveFileDialog)
        {
            Check.IfIsNull(saveFileDialog).Throw<ArgumentNullException>(() => saveFileDialog);

            this.saveFileDialog = saveFileDialog;
        }

        /// <summary>
        ///     Show the Save File Dialog.
        /// </summary>
        /// <returns></returns>
        public bool ShowDialog()
        {
            return saveFileDialog.ShowDialog().GetValueOrDefault();
        }
    }
}