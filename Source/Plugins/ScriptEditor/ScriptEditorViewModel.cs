using Editor.FileSystem.Dependencies.Events;
using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using System;
using System.IO;

namespace Editor.ScriptManager
{
    /// <summary>
    ///     The View Model for the Script Editor Control
    /// </summary>
    public class ScriptEditorViewModel : BaseViewModel
    {
        private readonly IScriptLoader scriptLoader;

        private readonly IScriptSerializer scriptSerializer;

        private string script;

        private IFile scriptFile;

        /// <summary>
        ///     The content of the text editor.
        /// </summary>
        public string Script
        {
            get { return script; }
            set { SetProperty(ref script, value); }
        }

        /// <summary>
        ///     Gets or sets the script file.
        /// </summary>
        /// <value>The script file.</value>
        public IFile ScriptFile
        {
            get { return scriptFile; }
            set { SetScriptFile(scriptFile, value); }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ScriptEditorViewModel" /> class.
        /// </summary>
        /// <param name="scriptLoader"> The script loader for the script. </param>
        /// <param name="scriptSerializer">The script serializer used to save the script to a file on disk</param>
        public ScriptEditorViewModel(IScriptLoader scriptLoader, IScriptSerializer scriptSerializer)
        {
            Check.IfIsNull(scriptLoader).Throw<ArgumentNullException>(() => scriptLoader);
            Check.IfIsNull(scriptSerializer).Throw<ArgumentNullException>(() => scriptSerializer);

            this.scriptLoader = scriptLoader;
            this.scriptSerializer = scriptSerializer;

            FileChangedEventHandler += OnFileChanged;
        }

        /// <summary>
        ///     Occurs when the file linked to the script editor is changed.
        /// </summary>
        public event EventHandler<FileChangedEventArgs> FileChangedEventHandler;

        /// <summary>
        ///     Determines whether the script can be saved.
        /// </summary>
        /// <returns><c>true</c> if the script can be saved; otherwise, <c>false</c>.</returns>
        public bool CanSave()
        {
            if (ScriptFile == null) return false;
            if (Script == null) return false;
            if (string.IsNullOrWhiteSpace(ScriptFile.FullPath)) return false;
            return !Directory.Exists(ScriptFile.Path);
        }

        /// <summary>
        ///     Saves the script to a file on disk.
        /// </summary>
        public void SaveScript()
        {
            Check.IfIsNull(ScriptFile).Throw<InvalidOperationException>(() => ScriptFile);
            Check.IfIsNull(Script).Throw<InvalidOperationException>(() => Script);
            scriptSerializer.Serialize(ScriptFile, Script);
        }

        /// <summary>
        ///     Synchronizes the editor (text editor control) to the content of the file.
        /// </summary>
        public void SyncEditor()
        {
            Check.IfIsNull(ScriptFile).Throw<NullReferenceException>(() => ScriptFile);
            Script = scriptLoader.LoadContent(ScriptFile);
        }

        /// <summary>
        ///     Called when the file has been changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        ///     The <see cref="FileChangedEventArgs" /> instance containing the event data.
        /// </param>
        private void OnFileChanged(object sender, FileChangedEventArgs e)
        {
            SyncEditor();
        }

        /// <summary>
        ///     Sets the script file.
        /// </summary>
        /// <param name="previousFile">The previous file.</param>
        /// <param name="currentFile">The current file.</param>
        private void SetScriptFile(IFile previousFile, IFile currentFile)
        {
            scriptFile = currentFile;
            if (FileChangedEventHandler == null || scriptFile == null) return;
            FileChangedEventHandler(this, new FileChangedEventArgs(previousFile, scriptFile));
        }
    }
}