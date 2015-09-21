using Editor.WindowShell.Dependencies;
using FluentChecker;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Editor.WindowShell.Dialogs
{
    public class EditorOpenFileDialog : IOpenFileDialog
    {
        private readonly OpenFileDialog openFileDialog;

        /// <summary>
        ///     Gets the name of the file.
        /// </summary>
        /// <value> The name of the file. </value>
        public string FileName
        {
            get { return openFileDialog.FileName; }
        }

        /// <summary>
        ///     Gets or sets the all the names of the selected files.
        /// </summary>
        /// <value>
        ///     The file names.
        /// </value>
        public IEnumerable<string> FileNames
        {
            get { return openFileDialog.FileNames; }
        }

        /// <summary>
        ///     Gets the file filter.
        /// </summary>
        /// <value> The filter. </value>
        public string Filter
        {
            get { return openFileDialog.Filter; }
        }

        /// <summary>
        ///     z
        ///     Gets or sets a value indicating whether this <see cref="IOpenFileDialog" /> should allow to select an indefinite
        ///     number of files.
        /// </summary>
        /// <value>
        ///     <c>true</c> if allow a multiselection; otherwise, <c>false</c>.
        /// </value>
        public bool Multiselect
        {
            get { return openFileDialog.Multiselect; }
            set { openFileDialog.Multiselect = value; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EditorSaveFileDialog" /> class.
        /// </summary>
        /// <param name="openFileDialog">The open file dialog.</param>
        public EditorOpenFileDialog(OpenFileDialog openFileDialog)
        {
            Check.IfIsNull(openFileDialog).Throw<ArgumentNullException>(() => openFileDialog);

            this.openFileDialog = openFileDialog;
        }

        /// <summary>
        ///     Show the Save File Dialog.
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public bool ShowDialog()
        {
            return openFileDialog.ShowDialog().GetValueOrDefault();
        }
    }
}