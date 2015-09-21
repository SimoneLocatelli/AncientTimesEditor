using Editor.Application.Dependencies;
using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Facades;
using FluentChecker;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Editor.WindowShell
{
    public class EditorApplication : IApplication
    {
        private IPathFacade pathFacade = new PathFacade();

        [ExcludeFromCodeCoverage]
        public string InstallationPath
        {
            get { return PathFacade.GetDirectoryName(Assembly.GetEntryAssembly().Location); }
        }

        [ExcludeFromCodeCoverage]
        public IPathFacade PathFacade
        {
            get { return pathFacade; }
            set
            {
                Check.IfIsNull(pathFacade).Throw<ArgumentNullException>(() => pathFacade);

                pathFacade = value;
            }
        }

        public event EventHandler OnApplicationClose;
    }
}