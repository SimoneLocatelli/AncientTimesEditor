using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dependencies.ScriptEditor;
using Editor.WindowShell.Dependencies.TabSystem;
using FluentChecker;
using System;
using Utils;

namespace Editor.TabSystem.TabFactoryItems
{
    /// <summary>
    ///     Class used to initalize new instances of TabItem for the ScriptEditor.
    /// </summary>
    public class ScriptEditorTabFactory : ITabFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptEditorTabFactory" /> class.
        /// </summary>
        public ScriptEditorTabFactory()
        {
        }

        /// <summary>
        ///     Creates a new tab that contains the contents read from the file in an instance of <see cref="ScriptEditor" />.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>TabItem.</returns>
        public TabItem Create(IFile file)
        {
            throw new NotImplementedException();
            //Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);
            //Check.IfIsNotOfType<Script>(file)
            //    .Throw<ArgumentException>(ArgumentExceptionMessagesFactory.InstanceIsNotExpectedType<Script>());

            //var scriptEditor = dependencyResolver.Resolve<IScriptEditor>();
            //scriptEditor.SetScriptFile(file);
            //return new TabItem(file.Name, scriptEditor.Control);
        }
    }
}