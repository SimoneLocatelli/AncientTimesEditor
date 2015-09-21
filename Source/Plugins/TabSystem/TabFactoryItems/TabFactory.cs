using Editor.FileSystem.Dependencies.FileEntities;
using Editor.WindowShell.Dependencies.TabSystem;
using System;

namespace Editor.TabSystem.TabFactoryItems
{
    public class TabFactory : ITabFactory
    {
        public TabItem Create(IFile file)
        {
            throw new NotImplementedException();

            //Check.IfIsNull(file).Throw<ArgumentNullException>(() => file);
            //var factory = dependencyResolver.Resolve<ITabFactory>(file.GetType());

            //return factory.Create(file);
        }
    }
}