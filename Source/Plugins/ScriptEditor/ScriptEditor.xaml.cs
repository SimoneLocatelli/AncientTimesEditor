using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.WindowShell.Dependencies.ScriptEditor;
using FluentChecker;
using System;
using System.Windows;

namespace Editor.ScriptManager
{
    /// <summary>
    ///     Interaction logic for ScriptEditor.xaml
    /// </summary>
    public partial class ScriptEditor : IScriptEditor
    {
        /// <summary>
        ///     Gets the <see cref="UIElement" /> control.
        /// </summary>
        /// <value> The control. </value>
        public UIElement Control
        {
            get { return this; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ScriptEditor" /> class.
        /// </summary>
        /// <param name="scriptLoader"> The script loader for the script. </param>
        /// <param name="scriptSerializer">The script serializer used to save the script to a file on disk</param>
        public ScriptEditor(IScriptLoader scriptLoader, IScriptSerializer scriptSerializer)
        {
            Check.IfIsNull(scriptLoader).Throw<ArgumentNullException>(() => scriptLoader);
            Check.IfIsNull(scriptSerializer).Throw<ArgumentNullException>(() => scriptSerializer);

            InitializeComponent();

            DataContext = new ScriptEditorViewModel(scriptLoader, scriptSerializer);
        }

        /// <summary>
        ///     Sets the script file.
        /// </summary>
        /// <param name="file">The file.</param>
        public void SetScriptFile(IFile file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);
            Check.IfIsNull((DataContext as ScriptEditorViewModel))
                .Throw<InvalidOperationException>(() => (DataContext as ScriptEditorViewModel));
            ((ScriptEditorViewModel)DataContext).ScriptFile = file;
        }
    }
}