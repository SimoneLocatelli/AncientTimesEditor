using Editor.FileSystem.Dependencies.FileEntities;
using Editor.FileSystem.FileEntities;
using Editor.WindowShell.Dependencies.TabSystem;
using FluentChecker;
using System;
using TabSystem;
using Utils;

namespace Editor.TabSystem.TabFactoryItems
{
    public class ProjectItemTabFactory : ITabFactory
    {
        public TabItem Create(IFile file)
        {
            Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);
            Check.IfIsNotOfType<Project>(file)
                .Throw<ArgumentException>(ArgumentExceptionMessagesFactory.InstanceIsNotExpectedType<Project>());

            return new TabItem(file.Name, new DummyControl());
        }
    }
}